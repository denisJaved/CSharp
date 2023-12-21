using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SpaceTerritory
{
    class DataHolder
    {
        public static Size windowSize;
        private static int _hp = Configs.maxHP;
        private static int _ammo = Configs.maxAmmo;
        private static int _reload = -1;
        public static int hp { 
            get { return _hp; }
            set {
                if (value > Configs.maxHP) {
                    _hp = Configs.maxHP;
                }
                _hp = value;
            }
        }
        public static int ammo { 
            get { return _ammo; }
            set {
                if (value > Configs.maxAmmo) {
                    _ammo = Configs.maxAmmo;
                }
                _ammo = value;
            }
        }
        public static int reload { 
            get { return _reload; }
            set
            {
                _reload = value;
                if (_reload < 0) {
                    _reload = 0;
                }
            }
        }
        public static bool shoot {
            get {
                if (_reload == 0)
                {
                    reload = Configs.reloadTime;
                    return true;
                }
                return false;
            }
        }
    }
    class Configs
    {
        public static readonly String skin = "1";
        public static readonly String assetsFolder = "assets";
        public static readonly String loseSound = "lose.wav";
        public static readonly String fireSound = "shoot.wav";
        public static readonly String fireFailSound = "noAmmo.wav";
        public static readonly String firstPlayer1 = "PL-" + skin + "-1.png";
        public static readonly String firstPlayer2 = "PL-" + skin + "-2.png";
        public static readonly String enemy = "enemy.png";
        public static readonly String barrier = "barrier.png";

        public static readonly char hpSymbol = '█';
        public static readonly char noHpSymbol = '▒';
        public static readonly char reloadSymbol = '█';
        public static readonly char noReloadSymbol = '▒';
        public static readonly char reloadedSymbol = '█';

        public static readonly int playerMovementSpeed = 8;
        public static readonly int playerMovementResolution = 4;
        public static readonly int playerMovementWaiting = 1;

        public static readonly int maxHP = 5;
        public static readonly int maxAmmo = 5;
        public static readonly int reloadTime = 3;

        public static readonly int bulletspeed = 10;
        public static readonly Size bulletSize = new Size(10, 30);
        public static readonly Color playerBulletColor = Color.White;
        
        public static readonly int tickRate = 100;

        public static readonly Color enemyBulletColor = Color.Purple;
        public static readonly int defaultEnemyHP = 2;
        public static readonly int defaultEnemySpeed = 5;
        public static readonly Size defaultEnemySize = new Size(96, 96);

        public static readonly Size defaultBarrierSize = new Size(96, 96);
        public static readonly int defaultBarrierHP = 5;

        public static readonly bool readMapCode = true;

        public static readonly bool startOptimizer = true;
        public static readonly bool sounds = true;
    }

    class Physics {
        public static void work(PhysicsObject pobject) {
            makeMove(pobject.control, pobject.velocity, pobject.speed);
        }
        public static void makeMove(Control control, Velocity velocity, int speed) {
            switch (velocity)
            {
                case Velocity.UP:
                    control.Top -= speed;
                    break;
                case Velocity.DOWN:
                    control.Top += speed;
                    break;
                case Velocity.LEFT:
                    control.Left -= speed;
                    break;
                case Velocity.RIGHT:
                    control.Left += speed;
                    break;
                case Velocity.UP_LEFT:
                    control.Top -= speed;
                    control.Left -= speed;
                    break;
                case Velocity.UP_RIGHT:
                    control.Top -= speed;
                    control.Left += speed;
                    break;
                case Velocity.DOWN_LEFT:
                    control.Top += speed;
                    control.Left -= speed;
                    break;
                case Velocity.DOWN_RIGHT:
                    control.Top += speed;
                    control.Left += speed;
                    break;
            }
        }

        public static bool colliding(PhysicsObject o1, PhysicsObject o2) {
            return colliding(o1.control, o2.control);
        }
        public static bool colliding(Control control, Control control1) {
            return control.Bounds.IntersectsWith(control1.Bounds);
        }
        
        public enum Velocity { 
            UP,
            DOWN,
            LEFT,
            RIGHT,
            UP_LEFT,
            UP_RIGHT,
            DOWN_LEFT,
            DOWN_RIGHT,

            ///
            /// ONLY for entitys
            /// 
            SHOT,
        }
        public class PhysicsObject { 
            public Velocity velocity;
            public int speed;
            public Control control;
        }
    }

    class Bullet : Physics.PhysicsObject
    {
        public enum BulletType { 
            PLAYER,
            EMEMY,
        }
        public BulletType type;
        public int damage = 1;
    }
    class Entity {
        public Control control;
        private bool _live;
        private int _hp;
        public int hp {
            get { 
                return _hp;
            }
            set { 
                _hp = value;
                if (_hp < 1) { 
                    _live = false;
                }
            }
        }
        public bool live { 
            get {
                return _live; 
            }
            set {
                if (value == false)
                {
                    _live = false;
                    _hp = 0;
                }
                else {
                    _live = true;
                    if (_hp < 1) {
                        _hp = 1;
                    }
                }
            }
        }
    }
    class Barrier : Entity {
        public static Barrier createDefaultBarrier(Form form) {
            Barrier b = new Barrier()
            {
                control = new PictureBox()
                {
                    ImageLocation = Path.Combine(Environment.CurrentDirectory, Configs.assetsFolder, Configs.barrier),
                    Size = Configs.defaultBarrierSize,
                },
                hp = Configs.defaultBarrierHP,
            };
            form.Controls.Add(b.control);
            return b;
        }
    }
    class Enemy : Entity {
        private int currectMove = 0;
        private Physics.Velocity[] moves;
        public int speed;
        public bool move() {
            if (currectMove >= moves.Length)
            {
                currectMove = 0;
            }
            if (moves[currectMove] == Physics.Velocity.SHOT) {
                currectMove++;
                return true;
            }
            Physics.makeMove(control, moves[currectMove], speed);
            currectMove++;
            return false;
            
        }
        public static Enemy createDefaultEnemy(Form form) {
            Enemy enemy = new Enemy
            {
                control = new PictureBox {
                    Size = Configs.defaultEnemySize,
                    ImageLocation = Path.Combine(Environment.CurrentDirectory, Configs.assetsFolder, Configs.enemy),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                },
                hp = Configs.defaultEnemyHP,
                moves = new Physics.Velocity[] {
                    Physics.Velocity.LEFT,
                    Physics.Velocity.LEFT,
                    Physics.Velocity.LEFT,
                    Physics.Velocity.RIGHT,
                    Physics.Velocity.DOWN_RIGHT,
                    Physics.Velocity.UP_RIGHT,
                    Physics.Velocity.DOWN_LEFT,
                    Physics.Velocity.DOWN,
                    Physics.Velocity.LEFT,
                    Physics.Velocity.SHOT,
                    Physics.Velocity.DOWN_RIGHT,
                    Physics.Velocity.UP_RIGHT,
                    Physics.Velocity.RIGHT,
                    Physics.Velocity.RIGHT,
                    Physics.Velocity.RIGHT,
                    Physics.Velocity.RIGHT,
                    Physics.Velocity.DOWN_LEFT,
                    Physics.Velocity.UP_LEFT,
                    Physics.Velocity.DOWN_RIGHT,
                    Physics.Velocity.DOWN,
                    Physics.Velocity.RIGHT,
                    Physics.Velocity.SHOT,
                    Physics.Velocity.DOWN_LEFT,
                    Physics.Velocity.UP_LEFT,
                },
                speed = Configs.defaultEnemySpeed,
            };
            form.Controls.Add(enemy.control);
            return enemy;
        }
    }
}
