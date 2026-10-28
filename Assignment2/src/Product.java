public class Product {
    //private variables
    private String name;
    private int quantity;
    private double price;

    //constructor
    public Product(String name, int quantity, double price){
        this.name = name;
        this.quantity = quantity;
        this.price = price;
    }

    //calcaulte the value of inventory for the product
    public double calcInventoryValue(){
        return this.price * this.quantity;
    }

    //access the private name variable
    public String getName(){
        return this.name;
    }
}
