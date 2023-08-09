package com.example.homemove;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }

    public void Home(View view){
        Intent intent = new Intent(this, home.class);
        startActivity(intent);
    }

    public void Cadastrar(View view){
        Intent intent = new Intent(this, cadastrar.class);
        startActivity(intent);
    }
}