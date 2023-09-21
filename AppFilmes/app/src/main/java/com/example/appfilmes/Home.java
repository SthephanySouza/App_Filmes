package com.example.appfilmes;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;

import com.example.appfilmes.filme.Filmes;

public class Home extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_home);
    }

    public void Filme(View filme){
        Intent filmes = new Intent(this, Filmes.class);
        startActivity(filmes);
    }

    /* public void Ator(View ator){
        Intent Ator = new Intent(this, Atores.class);
        startActivity(Ator);
    }

    public void Diretor(View diretor){
        Intent Diretor = new Intent(this, Diretores.class);
        startActivity(Diretor);
    }

    public void Genero(View genero){
        Intent Genero = new Intent(this, Generos.class);
        startActivity(Genero);
    } */
    
    /* public void Insert(View view){
        Intent intent = new Intent(this, Insert.class);
        startActivity(intent);
    }

    public void Consultar(View view){
        Intent intent = new Intent(this, Consultar.class);
        startActivity(intent);
    }

    public void Update(View view){
        Intent intent = new Intent(this, Update.class);
        startActivity(intent);
    } */
}