package com.example.appfilmes.filme;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import com.example.appfilmes.R;
import com.example.appfilmes.banco.BancoController;

public class Insert extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_insert);

        Button botao = (Button)findViewById(R.id.btninser);

        botao.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View filmes) {
                BancoController crud = new BancoController(getBaseContext());
                EditText NomeFilme = (EditText)findViewById(R.id.txtfilme);
                EditText Classific = (EditText)findViewById((R.id.txtclassific));
                EditText Genero = (EditText)findViewById((R.id.txtgenero));
                EditText DataLanc = (EditText)findViewById(R.id.txtdata);
                EditText Idioma = (EditText)findViewById(R.id.txtidioma);

                String filme = NomeFilme.getText().toString();
                String classific = Classific.getText().toString();
                String dataLanc = DataLanc.getText().toString();
                String genero = Genero.getText().toString();
                String idioma = Idioma.getText().toString();
                String resultado;

                resultado = crud.insertFilme(filme, classific, dataLanc, idioma, genero);

                Toast.makeText(getApplicationContext(), resultado, Toast.LENGTH_LONG).show();
            }
        });
    }
}