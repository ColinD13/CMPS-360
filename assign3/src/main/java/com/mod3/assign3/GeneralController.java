package com.mod3.assign3;

import java.util.Random;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class GeneralController {

    @GetMapping("/")
    public String home() {
        return "Hello from Spring Boot!";
    }

    @GetMapping("/hockey")
    public String hockey(){
        Random rand = new Random();
        int num = rand.nextInt(1,11);
        if(num > 5){
            return "Pittsburgh Penguins";
        }
        else{
            return "Philadelphia Flyers";
        }
    }

    @GetMapping("/football")
    public String football(){
        Random rand = new Random();
        int num = rand.nextInt(1,11);
        if(num > 5){
            return "Pittsburgh Steelers";
        }
        else{
            return "Baltimore Ravens";
        }
    }

    @GetMapping("/basketball")
    public String basketball(){
        Random rand = new Random();
        int num = rand.nextInt(1,11);
        if(num > 5){
            return "Golden State Warriors";
        }
        else{
            return "Miami Heat";
        }
    }
}