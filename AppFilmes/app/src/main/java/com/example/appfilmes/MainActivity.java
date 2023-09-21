package com.example.appfilmes;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }

    public void Home(View view){
        Intent intent = new Intent(this, Home.class);
        startActivity(intent);

        /* EditText editEmail = findViewById(R.id.txtemail);
        EditText editSenha = findViewById(R.id.txtsenha);

        String email = editEmail.getText().toString();
        String senha = editSenha.getText().toString();

        Banco db = new Banco(getApplicationContext());
        db.getReadableDatabase();

        if(db.retornoCadastrado(email,senha) != 0){
            SharedPreferences settings = getSharedPreferences("com.example.appleitour", 0);
            SharedPreferences.Editor editor = settings.edit();

            editor.putInt("UserId",db.retornoCadastrado(email,senha));
            editor.putInt("LastUser",db.retornoCadastrado(email,senha));
            editor.apply();

            Intent intent = new Intent(getApplicationContext(), Home.class);

            finish();
            startActivity(intent);
        }else {
            Toast.makeText(getApplicationContext(), "Usuario ou senha incorretos", Toast.LENGTH_SHORT).show();
        } */
    }

    public void Cadastro(View view){
        Intent intent = new Intent(this, Cadastro.class);
        startActivity(intent);
    }
}