package com.example.appfilmes.genero;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;

import com.example.appfilmes.R;
import com.example.appfilmes.genero.Buscar;

public class Generos extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_filmes);
    }
    
    public void Insert(View filme){
        Intent filmes = new Intent(this, Inser.class);
        startActivity(filmes);
    }

    public void Update(View filme){
        Intent filmes = new Intent(this, Alter.class);
        startActivity(filmes);
    }

    public void Buscar(View filme){
        Intent filmes = new Intent(this, Buscar.class);
        startActivity(filmes);
    }
}