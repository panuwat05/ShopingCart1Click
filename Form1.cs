namespace ShopingCart
{
    public partial class Form1 : Form
    {
        
        MenuItem itemCoffee = new MenuItem();
        MenuItem itemGreentea = new MenuItem();
        MenuItem itemNoodle = new MenuItem();
        MenuItem itemPizza = new MenuItem();

        public Form1()
        {
            InitializeComponent();

            
            itemCoffee.Name = "Coffee";
            itemCoffee.Price = 75;
            itemCoffee.Quantity = 0;

            itemGreentea.Name = "Greentea";
            itemGreentea.Price = 60;
            itemGreentea.Quantity = 0;

            itemNoodle.Name = "Noodle";
            itemNoodle.Price = 50;
            itemNoodle.Quantity = 0;

            itemPizza.Name = "Pizza";
            itemPizza.Price = 120;
            itemPizza.Quantity = 0;

            
            tbCoffeePrice.Text = itemCoffee.Price.ToString();
            tbCoffeeQuantity.Text = itemCoffee.Quantity.ToString();

            tbGreenteaPrice.Text = itemGreentea.Price.ToString();
            tbGreenteaQuantity.Text = itemGreentea.Quantity.ToString();

            tbNoodlePrice.Text = itemNoodle.Price.ToString();
            tbNoodleQuantity.Text = itemNoodle.Quantity.ToString();

            tbPizzaPrice.Text = itemPizza.Price.ToString();
            tbPizzaQuantity.Text = itemPizza.Quantity.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double dCash = double.Parse(tb_cash.Text);

                double dBeverageTotal = 0;
                double dFoodTotal = 0;

                
                if (chb_Coffee.Checked)
                {
                    itemCoffee.Quantity = int.Parse(tbCoffeeQuantity.Text);
                    dBeverageTotal += itemCoffee.GetTotalPrice();
                }
                if (chb_Greentea.Checked)
                {
                    itemGreentea.Quantity = int.Parse(tbGreenteaQuantity.Text);
                    dBeverageTotal += itemGreentea.GetTotalPrice();
                }

                
                if (chb_noodle.Checked)
                {
                    itemNoodle.Quantity = int.Parse(tbNoodleQuantity.Text);
                    dFoodTotal += itemNoodle.GetTotalPrice();
                }
                if (chb_pizza.Checked)
                {
                    itemPizza.Quantity = int.Parse(tbPizzaQuantity.Text);
                    dFoodTotal += itemPizza.GetTotalPrice();
                }

                double dGrandTotal = dBeverageTotal + dFoodTotal;

                
                double dTotalDiscount = CalculateTotalDiscount(dBeverageTotal, dFoodTotal, dGrandTotal);

                dGrandTotal -= dTotalDiscount;

                if (dCash < dGrandTotal)
                {
                    MessageBox.Show("Insufficient cash", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                double dChange = dCash - dGrandTotal;

                tbTotal.Text = dGrandTotal.ToString("F2");
                tbChange.Text = dChange.ToString("F2");

                CalculateChangeDenominations(dChange);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please fill in the numbers correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private double CalculateTotalDiscount(double dBeverageTotal, double dFoodTotal, double dGrandTotal)
        {
            double dDiscountBev = chb_beverage.Checked ? double.Parse(tbBeverageDiscount.Text) : 0;
            double dDiscountFood = chb_food.Checked ? double.Parse(tbFoodDiscount.Text) : 0;
            double dDiscountAll = chb_all.Checked ? double.Parse(tbTotalDiscount.Text) : 0;

            
            double dTotalDiscount = (dBeverageTotal * dDiscountBev / 100) + (dFoodTotal * dDiscountFood / 100) + (dGrandTotal * dDiscountAll / 100);

            return dTotalDiscount;
        }

        private void CalculateChangeDenominations(double change)
        {
            double[] denominations = { 1000, 500, 100, 50, 20, 10, 5, 1, 0.50, 0.25 };
            int[] changeCount = new int[denominations.Length];
            double remainChange = change;

            for (int i = 0; i < denominations.Length; i++)
            {
                changeCount[i] = (int)(remainChange / denominations[i]);
                remainChange %= denominations[i];
            }

            tb_1000.Text = changeCount[0].ToString();
            tb_500.Text = changeCount[1].ToString();
            tb_100.Text = changeCount[2].ToString();
            tb_50.Text = changeCount[3].ToString();
            tb_20.Text = changeCount[4].ToString();
            tb_10.Text = changeCount[5].ToString();
            tb_5.Text = changeCount[6].ToString();
            tb_1.Text = changeCount[7].ToString();
            tb_050.Text = changeCount[8].ToString();
            tb_025.Text = changeCount[9].ToString();
        }
    }
}
