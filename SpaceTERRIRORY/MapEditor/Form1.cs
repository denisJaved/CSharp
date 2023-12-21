using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void createStandartEnemy(object sender, EventArgs e)
        {
            PictureBox pictureBox = new PictureBox() {
                ImageLocation = Path.Combine(Environment.CurrentDirectory, "assets", "enemy.png"),
                Size = new Size(96, 96),
            };
            ControlExtension.Draggable(pictureBox, true);
            MapObject obj = new MapObject()
            {
                control = pictureBox,
                type = Type.Enemy,
                param = Param.DefaultEnemy,
            };
            objects.Add(obj);
            workspace.Controls.Add(obj.control);
        }
        private ArrayList objects = new ArrayList();

        private void exportMethods(object sender, EventArgs e)
        {
            StringBuilder output = new StringBuilder();

            foreach (MapObject mo in objects) { 
                switch (mo.type)
                {
                    case Type.Enemy:
                        switch (mo.param) { 
                            case Param.DefaultEnemy:
                                output.Append("spawnEnemy(new Point(");
                                output.Append(mo.control.Location.X);
                                output.Append(",");
                                output.Append(mo.control.Location.Y);
                                output.Append("));");
                                break;
                        }
                        break;
                    case Type.Barrier:
                        switch (mo.param) {
                            case Param.Basic:
                                output.Append("spawnBarrier(new Point(");
                                output.Append(mo.control.Location.X);
                                output.Append(",");
                                output.Append(mo.control.Location.Y);
                                output.Append("));");
                                break;
                        }
                        break;
                }
            }

            try
            {
                Clipboard.SetText(output.ToString());
            } catch {
                MessageBox.Show("Не удалось скопировать код карты(", "Итог", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MessageBox.Show("Код карты скопирован", "Итог");
        }

        private void createBasicBarrier(object sender, EventArgs e)
        {
            PictureBox pictureBox = new PictureBox()
            {
                ImageLocation = Path.Combine(Environment.CurrentDirectory, "assets", "barrier.png"),
                Size = new Size(96, 96),
            };
            ControlExtension.Draggable(pictureBox, true);
            MapObject obj = new MapObject()
            {
                control = pictureBox,
                type = Type.Barrier,
                param = Param.Basic,
            };
            objects.Add(obj);
            workspace.Controls.Add(obj.control);
        }

        private void exportCode(object sender, EventArgs e)
        {
            // SPWEN[10,10]
            StringBuilder output = new StringBuilder();

            foreach (MapObject mo in objects)
            {
                switch (mo.type)
                {
                    case Type.Enemy:
                        switch (mo.param)
                        {
                            case Param.DefaultEnemy:
                                output.Append("SPWEN[");
                                output.Append(mo.control.Location.X);
                                output.Append(",");
                                output.Append(mo.control.Location.Y);
                                output.Append("]");
                                break;
                        }
                        break;
                    case Type.Barrier:
                        switch (mo.param)
                        {
                            case Param.Basic:
                                output.Append("SPWBR[");
                                output.Append(mo.control.Location.X);
                                output.Append(",");
                                output.Append(mo.control.Location.Y);
                                output.Append("]");
                                break;
                        }
                        break;
                }
                output.Append(";");
            }

            try
            {
                Clipboard.SetText(output.ToString());
            }
            catch
            {
                MessageBox.Show("Не удалось скопировать код карты(", "Итог", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MessageBox.Show("Код карты скопирован", "Итог");
        }
    }

    class MapObject {
        public Control control;
        public Type type;
        public Param param;
        public HashSet<Object> objParams = new HashSet<object>();
    }
    enum Type { 
        Enemy,
        Barrier,
    }
    enum Param { 
        DefaultEnemy,
        Basic,
    }
}
