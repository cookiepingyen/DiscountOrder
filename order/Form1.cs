using order.Sales;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace order
{
    public partial class Form1 : Form
    {
        String[] foods = { "魚排飯$110", "雞排飯$95", "烤肉飯$90", "雞腿飯$100", "滷肉飯$50" };
        String[] meals = { "蘿蔔湯$30", "餛飩湯$40", "玉米濃湯$35" };
        String[] drinks = { "紅茶$20", "烏龍茶$25", "清茶$30" };
        List<Subtotal> subtotal_list = new List<Subtotal>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Factory.GetDiscount(comboBox1, subtotal_list);
            flowLayoutPanel4.createpanel4(subtotal_list, label2);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            foods.createfood(flowLayoutPanel1, NumericUpDown_ValueChanged, CheckBox_CheckedChanged);
            meals.createfood(flowLayoutPanel2, NumericUpDown_ValueChanged, CheckBox_CheckedChanged);
            drinks.createfood(flowLayoutPanel3, NumericUpDown_ValueChanged, CheckBox_CheckedChanged);
            comboBox1.Items.Add("打八折");
            comboBox1.Items.Add("打九折");
            comboBox1.Items.Add("雞腿飯送蘿蔔湯");
            comboBox1.Items.Add("烤肉飯買二送一");
            flowLayoutPanel4.create_subpanel_title();


        }

        private void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            //Numberic 跟 checkBox 綁定
            NumericUpDown Numberic = (NumericUpDown)sender;
            CheckBox checkBox = (CheckBox)Numberic.Tag;

            //new 一個Subtotal
            String food = checkBox.Text.Split('$')[0];
            int price = int.Parse(checkBox.Text.Split('$')[1]);
            int count = 0;
            Subtotal subtotal = new Subtotal(food, price, count, 0);

            if (Numberic.Value == 0)
            {
                checkBox.Checked = false;
                subtotal.count = (int)Numberic.Value;
                Subtotal item = subtotal_list.Where(x => x.Name == food).FirstOrDefault();
                if (item != null)
                {
                    subtotal_list.Remove(item);

                }

            }
            if (Numberic.Value >= 1)
            {
                checkBox.Checked = true;

                Subtotal item = subtotal_list.Where(x => x.Name == food).FirstOrDefault();
                if (item != null)
                {
                    item.count = (int)Numberic.Value;

                }
                else
                {
                    subtotal.count = 1;
                    subtotal_list.Add(subtotal);
                }
            }

            var discount = Factory.GetDiscount(comboBox1, subtotal_list);
            discount.Operation(subtotal_list);
            flowLayoutPanel4.createpanel4(subtotal_list, label2);
        }


        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            NumericUpDown Numberic = (NumericUpDown)checkBox.Tag;
            String food = checkBox.Text.Split('$')[0];
            int price = int.Parse(checkBox.Text.Split('$')[1]);
            int count = 0;
            int total = 0;
            Subtotal subtotal = new Subtotal(food, price, count, total);

            if (checkBox.Checked)
            {
                Numberic.Value = 1;

                Subtotal item = subtotal_list.Where(x => x.Name == food).FirstOrDefault();
                if (item != null)
                {
                    subtotal.count = (int)Numberic.Value;
                }
                else
                {
                    subtotal.count = 1;
                    subtotal_list.Add(subtotal);
                }
            }
            else
            {
                Numberic.Value = 0;

                Subtotal item = subtotal_list.Where(x => x.Name == food).FirstOrDefault();
                if (item != null)
                {
                    subtotal.count = (int)Numberic.Value;
                    subtotal_list.Remove(item);
                }
            }
            Factory.GetDiscount(comboBox1, subtotal_list);
            flowLayoutPanel4.createpanel4(subtotal_list, label2);

        }

    }
}

