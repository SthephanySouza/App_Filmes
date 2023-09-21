package com.example.appfilmes.filme;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;

import com.example.appfilmes.R;

public class Filmes extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_filmes);
    }
    
    public void Inserir(View filme){
        Intent filmes = new Intent(this, Insert.class);
        startActivity(filmes);
    }

    public void Alterar(View filme){
        Intent filmes = new Intent(this, Update.class);
        startActivity(filmes);
    }

    public void Consultar(View filme){
        Intent filmes = new Intent(this, Consultar.class);
        startActivity(filmes);
    }
}