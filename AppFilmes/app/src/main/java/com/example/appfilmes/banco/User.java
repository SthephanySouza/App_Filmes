package com.example.appfilmes.banco;

public class User {
    private int id;
    private String name;
    private String senha;
    private String email;

    public User(){

    }

    public User(String name, String password, String email){
        this.name = name;
        this.senha = password;
        this.email = email ;
    }

    public int getId() {return id;}
    public String getName(){return name;}
    public String getSenha(){return senha;}
    public String getEmail(){return email;}
}
