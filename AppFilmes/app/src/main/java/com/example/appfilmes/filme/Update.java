package com.example.appfilmes.filme;

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

public class Update extends AppCompatActivity {

    EditText filme;
    EditText classific;
    EditText genero;
    EditText dataLanc;
    EditText idioma;
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

        filme = (EditText)findViewById(R.id.txtfilme);
        classific = (EditText)findViewById((R.id.txtclassific));
        genero = (EditText)findViewById((R.id.txtgenero));
        dataLanc = (EditText)findViewById(R.id.txtdata);
        idioma = (EditText)findViewById(R.id.txtidioma);

        alterar = (Button)findViewById(R.id.button2);

        cursor = crud.CarregaId(Integer.parseInt(codigo));
        filme.setText(cursor.getString(cursor.getColumnIndexOrThrow(Banco.NOME_FILME)));
        classific.setText(cursor.getString(cursor.getColumnIndexOrThrow(Banco.CLASSIFIC)));
        genero.setText(cursor.getString(cursor.getColumnIndexOrThrow(Banco.GENERO)));
        dataLanc.setText(cursor.getString(cursor.getColumnIndexOrThrow(Banco.DATA_LANC)));
        idioma.setText(cursor.getString(cursor.getColumnIndexOrThrow(Banco.IDIOMA)));

        alterar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                crud.Alterar(Integer.parseInt(codigo),
                        filme.getText().toString(),classific.getText().toString(),
                        dataLanc.getText().toString(),idioma.getText().toString(),
                        genero.getText().toString());
                Intent intent = new Intent(Update.this,Consultar.class);
                startActivity(intent);
                finish();
            }
        });

        deletar = (Button)findViewById(R.id.button3);
        deletar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                crud.Deletar(Integer.parseInt(codigo));
                Intent intent = new Intent(Update.this,Consultar.class);
                startActivity(intent);
                finish();
            }
        });
    }
}