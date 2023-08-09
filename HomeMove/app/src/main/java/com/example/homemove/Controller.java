package com.example.homemove;

public class Controller {
    private String nome;
    private String login;
    private String senha;

    public Controller(String _nome, String _senha, String _login) {
        this.nome = _nome;
        this.login = _login;
        this.senha = _senha;
    }

    public String getNome(){
        return nome;
    }

    public String getLogin(){
        return login;
    }

    public String getSenha(){
        return senha;
    }

    public void setNome(String nome){
        this.nome = nome;
    }

    public void setogin(String email){
        this.login = email;
    }

    public void setSenha(String senha){
        this.senha = senha;
    }
}
