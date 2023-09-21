package com.example.appfilmes.genero;

import androidx.appcompat.app.AppCompatActivity;

import android.annotation.SuppressLint;
import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

import com.example.appfilmes.R;
import com.example.appfilmes.banco.Banco;
import com.example.appfilmes.banco.BancoController;
import com.example.appfilmes.filme.Update;

public class Alter extends AppCompatActivity {

    EditText filme;
    EditText genero;
    Button alterar;
    Button deletar;
    Cursor cursor;
    BancoController crud;
    String codigo;

    @SuppressLint("MissingInflatedId")
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_update);

        codigo = this.getIntent().getStringExtra("codigo");

        crud = new BancoController(getBaseContext());

        filme = (EditText)findViewById(R.id.editText4);
        genero = (EditText)findViewById(R.id.editText5);

        alterar = (Button)findViewById(R.id.button2);

        cursor = crud.BuscaId(Integer.parseInt(codigo));
        filme.setText(cursor.getString(cursor.getColumnIndexOrThrow(Banco.NOME_FILME)));
        genero.setText(cursor.getString(cursor.getColumnIndexOrThrow(Banco.GENERO)));

        alterar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                crud.Update(Integer.parseInt(codigo),
                        filme.getText().toString(),genero.getText().toString());
                Intent intent = new Intent(Alter.this,Buscar.class);
                startActivity(intent);
                finish();
            }
        });

        deletar = (Button)findViewById(R.id.button3);
        deletar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                crud.Delet(Integer.parseInt(codigo));
                Intent intent = new Intent(Alter.this,Buscar.class);
                startActivity(intent);
                finish();
            }
        });
    }
}