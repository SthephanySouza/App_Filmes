package com.example.appfilmes;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

public class Cadastro extends AppCompatActivity {

    // private static final String ARQUIVO_PREFERENCIA = "ArquivoPreferencia";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_cadastro);
    };

    public void Cadastrar(View view){
        Intent intent = new Intent(this, MainActivity.class);
        startActivity(intent);

        /* EditText editNome = findViewById(R.id.txtnome);
        EditText editEmail = findViewById(R.id.txtemail);
        EditText editSenha = findViewById(R.id.txtsenha);

        String nome = editNome.getText().toString().trim();
        String email = editEmail.getText().toString().trim();
        String senha = editSenha.getText().toString().trim();

        User user = new User(nome,email,senha);
        Banco db = new Banco(getApplicationContext());
        db.getWritableDatabase();

        if(db.cadastradoUsu(email)){
            Toast.makeText(getApplicationContext(),"Usuário já cadastrado",Toast.LENGTH_SHORT).show();
            return;
        }

        db.insereUsu(user);
        SharedPreferences settings = getSharedPreferences("com.example.appleitour", 0);
        SharedPreferences.Editor editor = settings.edit();
        editor.putInt("UserId",db.selectLastInsert());
        editor.putInt("LastUser",db.selectLastInsert());

        editor.apply();
        Intent intent = new Intent(getApplicationContext(),MainActivity.class);
        finish();
        startActivity(intent); */
    }

        /* EditText txtnome = findViewById(R.id.txtnome);
        EditText txtemail = findViewById(R.id.txtemail);
        EditText txtsenha = findViewById(R.id.txtsenha);
        TextView resultado = findViewById(R.id.entre);
        Button botao = (Button)findViewById(R.id.btncadastrar);

        botao.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                SharedPreferences preferences = getSharedPreferences(ARQUIVO_PREFERENCIA, 0);
                SharedPreferences.Editor editor = preferences.edit();

                if(txtnome.getText().toString().equals("")){
                    Toast.makeText(getApplicationContext(), "preencher seu nome", Toast.LENGTH_LONG).show();
                }
                else if(txtemail.getText().toString().equals("")){
                    Toast.makeText(getApplicationContext(), "preencher seu email", Toast.LENGTH_LONG).show();
                }
                else if(txtsenha.getText().toString().equals("")){
                    Toast.makeText(getApplicationContext(), "preencher sua senha", Toast.LENGTH_LONG).show();
                }
                else{
                    String nome = txtnome.getText().toString();
                    String email = txtemail.getText().toString();
                    String senha = txtsenha.getText().toString();

                    editor.putString("Nome", nome);
                    editor.putString("Email", email);
                    editor.putString("Senha", senha);
                    editor.commit();

                    resultado.setText("Login: " + nome + "\n" + "Email: " + email + "\n" + "Senha: " + senha);
                }
            }
        });

        SharedPreferences preferences = getSharedPreferences(ARQUIVO_PREFERENCIA, 0);

        if(preferences.contains("Nome") && preferences.contains("Email") && preferences.contains("Senha")){
            String nome = preferences.getString("Nome", "Olá, nome do usuário não definido");
            String email = preferences.getString("Email", "Olá, email do usuário não definido");
            String senha = preferences.getString("Senha", "Olá, senha do usuário não definido");
            resultado.setText("Login: " + nome + "\n" + "Email: " + email + "\n" + "Senha: " + senha);
        }
        else{
            resultado.setText("Olá, usuário não definido");
        } */

        /* botao.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                BancoController crud = new BancoController(getBaseContext());
                EditText nome = (EditText)findViewById(R.id.txtnome);
                EditText email = (EditText)findViewById((R.id.txtemail));
                EditText senha = (EditText)findViewById(R.id.txtsenha);

                String nomeString = nome.getText().toString();
                String emailString = email.getText().toString();
                String senhaString = senha.getText().toString();
                String resultado;

                resultado = crud.insereDado(nomeString,emailString,senhaString);

                Toast.makeText(getApplicationContext(), resultado, Toast.LENGTH_LONG).show();
            }
        });*/
}