package com.example.homemove;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.TextView;
import android.widget.Toast;

public class cadastrar extends AppCompatActivity {

    private Banco dbFilmes;

    TextView nome;
    TextView login;
    TextView senha;
    TextView confirmar;
    Button btn;
    Controller controller;
    TextView texto;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_cadastrar);

        nome = findViewById(R.id.txtnome);
        login = findViewById(R.id.txtlogin);
        senha = findViewById(R.id.txtsenha);
        confirmar = findViewById(R.id.txtconfirmar);
        btn = findViewById(R.id.btncadastrar);
        texto = findViewById(R.id.welcome_txt);

        dbFilmes = new Banco(this);
    }

    public void cadastrar(View view) {

        String nomes = nome.getText().toString();
        String logins = login.getText().toString();
        String senhas = senha.getText().toString();

        controller = new Controller(nomes, logins, senhas);

        System.out.println(controller);

        if (dbFilmes.insertUsuario(controller)) {
            texto.setText("Cadastro efetuado");
        } else {
            texto.setText("Erro no cadastro");
        }
    }

    public void TelaPrincipal(View view){
        Intent intent = new Intent(this, MainActivity.class);
        startActivity(intent);
    }
}