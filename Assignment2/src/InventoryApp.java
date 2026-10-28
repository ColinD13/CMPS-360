import javax.swing.JOptionPane;

public class InventoryApp {
    public static void main(String[] args) {
        //create two products
        Product p1 = new Product("Basketball", 2, 5);
        Product p2 = new Product("Football", 3, 7);

        //calculate the inventory value for each product
        double p1_inv_val = p1.calcInventoryValue();
        double p2_inv_val = p2.calcInventoryValue();
        double total_inv_val = p1_inv_val + p2_inv_val;

        //print the inventory info the console
        System.out.println(p1.getName() + " inventory value: " + p1_inv_val);
        System.out.println(p2.getName() + " inventory value: " + p2_inv_val);
        System.out.println("Total Inventory Value: " + total_inv_val);

        //print the inventory info to the JOptionPane
        JOptionPane.showMessageDialog(null, 
            p1.getName() + " - Value: " + p1_inv_val + "\n"
            + p2.getName() + " - Value: " + p2_inv_val + "\n" +
            "Total Inventory - Value: " + total_inv_val);
    }


}
