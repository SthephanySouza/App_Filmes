package com.example.appfilmes.api;

import android.content.Context;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.loader.content.AsyncTaskLoader;

import com.example.appfilmes.api.NetworkUtils;

public class CarregaGenero extends AsyncTaskLoader<String> {
    private String mQueryString;
    public CarregaGenero(Context context, String queryString) {
        super(context);
        mQueryString = queryString;
    }
    @Override
    protected void onStartLoading() {
        super.onStartLoading();
        forceLoad();
    }
    @Nullable
    @Override
    public String loadInBackground() {
        return NetworkUtils.BuscaGenero(mQueryString);
    }
}