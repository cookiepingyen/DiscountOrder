using Newtonsoft.Json;
using order.Sales;
using Order策略模式.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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

            flowLayoutPanel4.createpanel4(subtotal_list, label2);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string json = File.ReadAllText(@"C:\Users\user\source\repos\C#基礎專案\order_clone\Order策略模式\menu.json");

            MenuModel menuModel = JsonConvert.DeserializeObject<MenuModel>(json);

            foreach (MenuModel.Menu menu in menuModel.Menus)
            {
                FlowLayoutPanel foodPanel = new FlowLayoutPanel();
                foodPanel.Width = (container.Width / 2) - 10;
                foodPanel.Height = (container.Height / 2) - 10;

                Label titleLabel = new Label();
                titleLabel.Text = menu.FoodType;

                FlowLayoutPanel foodItems = new FlowLayoutPanel();
                foodItems.Width = foodPanel.Width;
                foodItems.Height = foodPanel.Height;
                foodItems.AutoScroll = true;
                string[] menuString = menu.Foods.Select(x => $"{x.Name}${x.Price}").ToArray();
                menuString.createfood(foodItems, NumericUpDown_ValueChanged, CheckBox_CheckedChanged);

                foodPanel.Controls.Add(titleLabel);
                foodPanel.Controls.Add(foodItems);


                container.Controls.Add(foodPanel);
            }






            //comboBox1.Items.Add("打八折");
            //comboBox1.Items.Add("打九折");
            //comboBox1.Items.Add("雞腿飯送蘿蔔湯");
            //comboBox1.Items.Add("烤肉飯買二送一");

            comboBox1.DataSource = menuModel.Discounts;
            comboBox1.DisplayMember = "Title";
            comboBox1.ValueMember = "Strategy";
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
            //DiscountContext discount = new DiscountContext(comboBox1.Text);
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

            var discount = Factory.GetDiscount(comboBox1, subtotal_list);
            discount.Operation(subtotal_list);


            flowLayoutPanel4.createpanel4(subtotal_list, label2);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

