using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceTerritory
{
    public partial class Form1 : Form
    {
        SoundPlayer loseSound = new SoundPlayer(Path.Combine(Environment.CurrentDirectory, Configs.assetsFolder, Configs.loseSound));
        SoundPlayer shootSound = new SoundPlayer(Path.Combine(Environment.CurrentDirectory, Configs.assetsFolder, Configs.fireSound));
        SoundPlayer shootFailSound = new SoundPlayer(Path.Combine(Environment.CurrentDirectory, Configs.assetsFolder, Configs.fireFailSound));
        public Form1()
        {
            InitializeComponent();

            // spawn enemies
            if (Configs.readMapCode) {
                String mapCode = Prompt.ShowDialog("Код карты:", "Код карты");
                String[] comms = mapCode.Split(';');
                foreach (String command in comms) {
                    String c = (string) command.Clone();
                    if (command.StartsWith("SPW")) {         // spawn
                        c = c.Substring(3);
                        if (c.StartsWith("EN[")) {           // enemy
                            c = c.Substring(3);
                            String[] values = c.Split(',');
                            values[values.Length - 1] = values[values.Length - 1].Replace("]", "");
                            Console.WriteLine(values[1]);
                            spawnEnemy(new Point(int.Parse(values[0]), int.Parse(values[1])));
                        } else if (c.StartsWith("BR[")) {    // barrier
                            c = c.Substring(3);
                            String[] values = c.Split(',');
                            values[values.Length - 1] = values[values.Length - 1].Replace("]", "");
                            Console.WriteLine(values[1]);
                            spawnBarrier(new Point(int.Parse(values[0]), int.Parse(values[1])));
                        }
                    }
                }
            }

            /*spawnEnemy(new Point(10, 10));
            spawnEnemy(new Point(121, 10));
            spawnEnemy(new Point(232, 10));
            spawnEnemy(new Point(343, 10));
            spawnEnemy(new Point(454, 10));
            spawnEnemy(new Point(565, 10));
            spawnEnemy(new Point(676, 10));

            spawnBarrier(new Point(10, 200));
            spawnBarrier(new Point(100, 200));
            spawnBarrier(new Point(300, 200));*/

            ticker.Interval = Configs.tickRate;
            bulletTicker.Interval = Configs.tickRate;
            enemyTicker.Interval = Configs.tickRate;
            optimizerTicker.Interval = Configs.tickRate;
            optimizerTicker.Enabled = Configs.startOptimizer;
        }

        private void resize(object sender, EventArgs e)
        {
            base.Width = DataHolder.windowSize.Width;
            base.Height = DataHolder.windowSize.Height;
            if (base.WindowState == FormWindowState.Maximized)
            {
                base.WindowState = FormWindowState.Normal;
                base.CenterToScreen();
            }
            MessageBox.Show("НЕЛЬЗЯ!", "Space Territory | Приказ игроку", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void shown(object sender, EventArgs e)
        {
            DataHolder.windowSize = new Size(base.Size.Width, base.Size.Height);
            player.ImageLocation = Path.Combine(Environment.CurrentDirectory, Configs.assetsFolder, Configs.firstPlayer1);
        }

        private void down(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    A = true;
                    break;
                case Keys.D:
                    D = true;
                    break;
                case Keys.E:
                    E = true;
                    break;
            }
        }

        private void up(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    A = false;
                    break;
                case Keys.D:
                    D = false;
                    break;
                case Keys.E:
                    E = false;
                    break;
            }
        }
        private bool D = false; // move left
        private bool A = false; // move right
        private bool E = false; // fire
        private void tickHandler(object sender, EventArgs e)
        {
            if (DataHolder.hp < 1) {
                ticker.Enabled = false;
                enemyTicker.Enabled = false;
                bulletTicker.Enabled = false;
                optimizerTicker.Enabled = false;

                if (Configs.sounds) loseSound.Play();
                DialogResult dr = MessageBox.Show("Вы проиграли. \nХотите назачть заного?", "Space Territory | MRBEAST", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (((int)dr) == 7) Environment.Exit(0);
                else if (((int)dr) == 6) {
                    Application.Restart();
                    Environment.Exit(0);
                }
            }
            DataHolder.reload -= 1;
            labelRender();
            controls();
        }
        private void labelRender() {
            StringBuilder sb = new StringBuilder();
            sb.Append("HP: ");
            sb.Append(Configs.hpSymbol, DataHolder.hp);
            sb.Append(Configs.noHpSymbol, Configs.maxHP - DataHolder.hp);
            sb.Append(" | Reloading: ");
            if (!(DataHolder.reload < 1))
            {
                sb.Append(Configs.reloadSymbol, DataHolder.reload);
                sb.Append(Configs.noReloadSymbol, Configs.reloadTime - DataHolder.reload);
            }
            else {
                sb.Append(Configs.reloadedSymbol, Configs.reloadTime);
            }
            label.Text = sb.ToString();
        }
        private void controls()
        {
            if (A)
            {
                for (int i = 0; i <= Configs.playerMovementResolution; i++)
                {
                    player.Left -= Configs.playerMovementSpeed / Configs.playerMovementResolution;
                    checkPlayersPos();
                    Thread.Sleep(Configs.playerMovementWaiting);
                }
            }
            if (D)
            {
                for (int i = 0; i <= Configs.playerMovementResolution; i++)
                {
                    player.Left += Configs.playerMovementSpeed / Configs.playerMovementResolution;
                    checkPlayersPos();
                    Thread.Sleep(Configs.playerMovementWaiting);
                }
            }
            if (E) {
                if (DataHolder.shoot)
                {
                    if (Configs.sounds) shootSound.Play();
                    spawnPlayerBullet(new Point(player.Left + (player.Width / 2), player.Top));
                }
                else {
                    if (Configs.sounds) shootFailSound.Play();
                }
            }
        }
        private void checkPlayersPos() {
            if (player.Left < 0)
            {
                player.Left = 0;
            }
            if (player.Left + player.Width > DataHolder.windowSize.Width)
            {
                player.Left = DataHolder.windowSize.Width - player.Width;
            }
        }
        private ArrayList bullets = new ArrayList();
        private ArrayList enemys = new ArrayList();
        private ArrayList barriers = new ArrayList();
        private void spawnBullet(Point pos, Bullet.BulletType type, Physics.Velocity velocity, int speed, Color color) {
            Bullet bullet = new Bullet();
            bullet.control = new Panel
            {
                Size = Configs.bulletSize,
                Location = pos,
                BackColor = color
            };
            bullet.velocity = velocity;
            bullet.type = type;
            bullet.speed = speed;

            base.Controls.Add(bullet.control);
            bullets.Add(bullet);
        }
        private void spawnPlayerBullet(Point pos) {
            spawnBullet(pos, Bullet.BulletType.PLAYER, Physics.Velocity.UP, Configs.bulletspeed, Configs.playerBulletColor);
        }
        private void spawnEnemyBullet(Point pos)
        {
            spawnBullet(pos, Bullet.BulletType.EMEMY, Physics.Velocity.DOWN, Configs.bulletspeed, Configs.enemyBulletColor);
        }
        private void spawnEnemy(Point pos) { 
            Enemy enemy = Enemy.createDefaultEnemy(this);
            enemy.control.Location = pos;
            enemys.Add(enemy);
        }
        private void spawnBarrier(Point pos) { 
            Barrier barrier = Barrier.createDefaultBarrier(this);
            barrier.control.Location = pos;
            barriers.Add(barrier);
        }

        private void bulletTick(object sender, EventArgs e)
        {
            // bullets
            for (int i = 0; i < bullets.Count; i++)
            {
                Bullet bullet = (Bullet)bullets[i];
                Physics.work(bullet);
                if (bullet.control.Top < 1)
                {
                    bullets.Remove(bullet);
                    base.Controls.Remove(bullet.control);
                }
                if (bullet.control.Top + bullet.control.Height > base.Height)
                {
                    bullets.Remove(bullet);
                    base.Controls.Remove(bullet.control);
                }
            }

            // coliders
            for (int i = 0; i < bullets.Count; i++) {
                Bullet b = (Bullet) bullets[i];
                
                bool collided = false;
                for (int f = 0; f < barriers.Count; f++) { 
                    Barrier bb = (Barrier)barriers[f];
                    if (Physics.colliding(b.control, bb.control)) {
                        bullets.Remove((Bullet)b);
                        base.Controls.Remove(b.control);
                        bb.hp--;
                        if (bb.hp < 1)
                        {
                            barriers.Remove(bb);
                            base.Controls.Remove(bb.control);
                        }
                    }
                }

                if (b.type == Bullet.BulletType.PLAYER)
                {
                    for (int f = 0; f < enemys.Count; f++)
                    {
                        Enemy ee = (Enemy)enemys[f];
                        if (Physics.colliding(b.control, ee.control))
                        {
                            bullets.Remove((Bullet)b);
                            base.Controls.Remove(b.control);
                            ee.hp--;
                            if (ee.hp < 1) { 
                                enemys.Remove(ee);
                                base.Controls.Remove(ee.control);
                            }
                        }
                    }
                }
                else if (b.type == Bullet.BulletType.EMEMY) {
                    if (Physics.colliding(b.control, player)) {
                        bullets.Remove((Bullet)b);
                        base.Controls.Remove(b.control);
                        DataHolder.hp -= 1;
                    }
                }
            }
        }

        private void enemyTick(object sender, EventArgs e)
        {
            // enemys
            for (int i = 0; i < enemys.Count; i++)
            {
                Enemy enemy = (Enemy)enemys[i];
                if (enemy.move())
                {
                    spawnEnemyBullet(new Point(enemy.control.Left + enemy.control.Width / 2, enemy.control.Top + enemy.control.Height));
                }
                if (enemy.control.Top + enemy.control.Size.Height > base.Size.Height)
                {
                    enemys.Remove(enemy);
                    base.Controls.Remove(enemy.control);
                }
            }
        }
        private void optimizerTick(object sender, EventArgs e)
        {
            for (int i = 0; i < bullets.Count; i++) {
                bool destroy = false;
                Bullet b = (Bullet)bullets[i];
                for (int f = 0; f < bullets.Count; f++)
                {
                    Bullet g = (Bullet)bullets[f];
                    if (b == g) {
                        continue;
                    }
                    if (b.type == g.type && (b.control.Size.Equals(g.control.Size) && b.control.Location.Equals(g.control.Location))) { 
                        destroy = true; break;
                    }
                }
                if (destroy)
                {
                    bullets.Remove(b);
                    base.Controls.Remove(b.control);
                }
            }
        }
    }
    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;
            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}
