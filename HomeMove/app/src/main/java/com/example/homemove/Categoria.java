package com.example.homemove;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;
import androidx.loader.app.LoaderManager;
import androidx.loader.content.Loader;

import android.annotation.SuppressLint;
import android.content.Context;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.os.Bundle;
import android.view.View;
import android.view.inputmethod.InputMethodManager;
import android.widget.EditText;
import android.widget.TextView;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

public class Categoria extends AppCompatActivity implements LoaderManager.LoaderCallbacks<String> {
    private EditText idFilme;
    private TextView nome;
    private TextView img;

    @SuppressLint("MissingInflatedId")
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_categoria);

        idFilme = findViewById(R.id.filmeInput);
        nome = findViewById(R.id.nome);
        img = findViewById(R.id.img);
        if (getSupportLoaderManager().getLoader(0) != null) {
            getSupportLoaderManager().initLoader(0, null, this);
        }
    }

    public void buscaFilmes(View view) {
        String queryString = idFilme.getText().toString();
        InputMethodManager inputManager = (InputMethodManager)
                getSystemService(Context.INPUT_METHOD_SERVICE);
        if (inputManager != null) {
            inputManager.hideSoftInputFromWindow(view.getWindowToken(),
                    InputMethodManager.HIDE_NOT_ALWAYS);
        }

        ConnectivityManager connMgr = (ConnectivityManager)
                getSystemService(Context.CONNECTIVITY_SERVICE);
        NetworkInfo networkInfo = null;
        if (connMgr != null) {
            networkInfo = connMgr.getActiveNetworkInfo();
        }

        if (networkInfo != null && networkInfo.isConnected()
                && queryString.length() != 0) {
            Bundle queryBundle = new Bundle();
            queryBundle.putString("queryString", queryString);
            getSupportLoaderManager().restartLoader(0, queryBundle, this);
            img.setText(R.string.strEmpty);
            nome.setText(R.string.loading);
        } else {
            if (queryString.length() == 0) {
                img.setText(R.string.strEmpty);
                nome.setText(R.string.noSearch);
            } else {
                img.setText(" ");
                nome.setText(R.string.noNetwork);
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
            JSONObject jsonObject = new JSONObject(data);
            JSONArray itemsArray = jsonObject.getJSONArray("items");
            int i = 0;
            String nome = null;
            String img = null;
            while (i < itemsArray.length() &&
                    (img == null && nome == null)) {
                JSONObject book = itemsArray.getJSONObject(i);
                JSONObject volumeInfo = book.getJSONObject("nomeFilme");
                try {
                    nome = volumeInfo.getString("Nome");
                    img = volumeInfo.getString("Imagem");
                } catch (JSONException e) {
                    e.printStackTrace();
                }
                i++;
            }

            if (nome != null && img != null) {
                nome.split(nome);
                img.split(img);
            } else {
                nome.split(String.valueOf(R.string.noResults));
                img.split(String.valueOf(R.string.strEmpty));
            }
        } catch (Exception e) {
            nome.setText(R.string.noResults);
            img.setText(R.string.strEmpty);
            e.printStackTrace();
        }
    }

    @Override
    public void onLoaderReset(@NonNull Loader<String> loader) {

    }
}