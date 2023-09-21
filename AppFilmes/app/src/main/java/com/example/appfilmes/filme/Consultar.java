package com.example.appfilmes.filme;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;
import androidx.cursoradapter.widget.SimpleCursorAdapter;
import androidx.loader.app.LoaderManager;
import androidx.loader.content.Loader;

import android.annotation.SuppressLint;
import android.content.Context;
import android.content.Intent;
import android.database.Cursor;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.os.Bundle;
import android.view.View;
import android.view.inputmethod.InputMethodManager;
import android.widget.AdapterView;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TextView;

import com.example.appfilmes.R;
import com.example.appfilmes.api.CarregaFilmes;
import com.example.appfilmes.banco.Banco;
import com.example.appfilmes.banco.BancoController;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

public class Consultar  extends AppCompatActivity implements LoaderManager.LoaderCallbacks<String> {

    // private ListView lista;

    private EditText nomeFilme;
    private TextView generos;
    private TextView idiomas;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_consultar);

        nomeFilme = findViewById(R.id.filmeInput);
        generos = findViewById(R.id.generoText);
        idiomas = findViewById(R.id.idiomaText);

        if (getSupportLoaderManager().getLoader(0) != null) {
            getSupportLoaderManager().initLoader(0, null, this);
        }

        /* BancoController crud = new BancoController(getBaseContext());
        final Cursor cursor = crud.Carregar();

        String[] nomeCampos = new String[] {Banco.ID_FILME, Banco.NOME_FILME};
        int[] idViews = new int[] {R.id.txtfilme, R.id.txtnome};

        SimpleCursorAdapter adaptador = new SimpleCursorAdapter(getBaseContext(),
                R.layout.activity_filmes,cursor,nomeCampos,idViews, 0);
        lista = (ListView)findViewById(R.id.listView);
        lista.setAdapter(adaptador);
        lista.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                String codigo;
                cursor.moveToPosition(position);
                codigo = cursor.getString(cursor.getColumnIndexOrThrow(Banco.ID_FILME));
                Intent intent = new Intent(Consultar.this, Update.class);
                intent.putExtra("codigo", codigo);
                startActivity(intent);
                finish();
            }
        }); */
    }

    @SuppressLint("MissingPermission")
    public void BuscaFilmes(View view) {
        // Recupera a string de busca.
        String queryString = nomeFilme.getText().toString();
        // esconde o teclado qdo o botão é clicado
        InputMethodManager inputManager = (InputMethodManager)
                getSystemService(Context.INPUT_METHOD_SERVICE);
        if (inputManager != null) {
            inputManager.hideSoftInputFromWindow(view.getWindowToken(),
                    InputMethodManager.HIDE_NOT_ALWAYS);
        }

        // Verifica o status da conexão de rede
        ConnectivityManager connMgr = (ConnectivityManager)
                getSystemService(Context.CONNECTIVITY_SERVICE);
        NetworkInfo networkInfo = null;
        if (connMgr != null) {
            networkInfo = connMgr.getActiveNetworkInfo();
        }
        /* Se a rede estiver disponivel e o campo de busca não estiver vazio
         iniciar o Loader CarregaFilmes */
        if (networkInfo != null && networkInfo.isConnected()
                && queryString.length() != 0) {
            Bundle queryBundle = new Bundle();
            queryBundle.putString("queryString", queryString);
            getSupportLoaderManager().restartLoader(0, queryBundle, this);
            generos.setText(R.string.str_empty);
            idiomas.setText(R.string.loading);
        }
        // atualiza a textview para informar que não há conexão ou termo de busca
        else {
            if (queryString.length() == 0) {
                generos.setText(R.string.str_empty);
                idiomas.setText(R.string.no_search_term);
            } else {
                generos.setText(" ");
                idiomas.setText(R.string.no_network);
            }
        }
    }

    @NonNull
    @Override
    public Loader<String> onCreateLoader(int id, @Nullable Bundle args) {
        String queryString = "";
        if (args != null) {
            queryString = args.getString("queryString");
        }
        return new CarregaFilmes(this, queryString);
    }
    @Override
    public void onLoadFinished(@NonNull Loader<String> loader, String data) {
        try {
            // Converte a resposta em Json
            JSONObject jsonObject = new JSONObject(data);
            // Obtem o JSONArray dos itens de livros
            JSONArray itemsArray = jsonObject.getJSONArray("items");
            // inicializa o contador
            int i = 0;
            String genero = null;
            String idioma = null;
            // Procura pro resultados nos itens do array
            while (i < itemsArray.length() &&
                    (idioma == null && genero == null)) {
                // Obtem a informação
                JSONObject filmes = itemsArray.getJSONObject(i);
                JSONObject volumeInfo = filmes.getJSONObject("volumeInfo");
                //  Obter autor e titulo para o item,
                // erro se o campo estiver vazio
                try {
                    genero = volumeInfo.getString("genero");
                    idioma = volumeInfo.getString("idioma");
                } catch (JSONException e) {
                    e.printStackTrace();
                }
                // move para a proxima linha
                i++;
            }
            //mostra o resultado qdo possivel.
            if (genero != null && idioma != null) {
                generos.setText(genero);
                idiomas.setText(idioma);
                //nmLivro.setText(R.string.str_empty);
            } else {
                // If none are found, update the UI to show failed results.
                generos.setText(R.string.no_results);
                idiomas.setText(R.string.str_empty);
            }
        } catch (Exception e) {
            // Se não receber um JSOn valido, informa ao usuário
            generos.setText(R.string.no_results);
            idiomas.setText(R.string.str_empty);
            e.printStackTrace();
        }
    }

    @Override
    public void onLoaderReset(@NonNull Loader<String> loader) {
        // obrigatório implementar, nenhuma ação executada
    }
}