package com.example.appfilmes.banco;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

import androidx.annotation.NonNull;

public class Banco extends SQLiteOpenHelper {
    public static final String NOME_BANCO = "banco.db";
    public static final String TABELA = "Cadastro";
    public static final String ID = "id";
    public static final String NOME = "nome";
    public static final String EMAIL = "email";
    public static final String SENHA = "senha";
    public static final String ID_FILME = "idFilme";
    public static final String TABELA_FILME = "Filmes";
    public static final String NOME_FILME = "nomeFilme";
    public static final String GENERO = "genero";
    public static final String CLASSIFIC = "classific";
    public static final String DATA_LANC = "dataLanc";
    public static final String IDIOMA = "idioma";
    public static final int VERSAO = 1;

    public Banco(Context context){
        super(context, NOME_BANCO,null,VERSAO);
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        String sql = "CREATE TABLE"+TABELA+"("
                + ID + " integer primary key autoincrement,"
                + NOME + " text,"
                + EMAIL + " text,"
                + SENHA + " text"
                +")";

        String filme = "CREATE TABLE"+TABELA_FILME+"("
                + ID_FILME + " integer primary key autoincrement,"
                + NOME_FILME + " text,"
                + GENERO + " text,"
                + CLASSIFIC + " text,"
                + DATA_LANC + " text"
                + IDIOMA + " text"
                +")";
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        db.execSQL("DROP TABLE IF EXISTS " + TABELA);
        onCreate(db);

        db.execSQL("DROP TABLE IF EXISTS " + TABELA_FILME);
        onCreate(db);
    }

    /* @Override
    public void onCreate(SQLiteDatabase database) {
        String sql = "CREATE TABLE"+TABELA+"("
                + ID + " integer primary key autoincrement,"
                + NOME + " text,"
                + EMAIL + " text,"
                + SENHA + " text"
                +")";
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        db.execSQL("DROP TABLE IF EXISTS " + TABELA_FILME);
        onCreate(db);
    } */

    /* public void insereUsu(@NonNull User user){
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues contentValues = new ContentValues();
        contentValues.put(Banco.NOME, user.getName());
        contentValues.put(Banco.EMAIL, user.getEmail());
        contentValues.put(Banco.SENHA, user.getSenha());

        db.insert(Banco.TABELA,null, contentValues);
    } */

    /* public int selectLastInsert(){
        SQLiteDatabase db = this.getReadableDatabase();
        String query = "Select last_insert_rowid();";
        Cursor cursor = null;
        if(db != null)
            cursor = db.rawQuery(query, null);
        cursor.moveToFirst();

        return cursor.getInt(0);
    }

    public boolean cadastradoUsu(String email){
        SQLiteDatabase db = this.getReadableDatabase();
        String query = "Select * from " + Banco.TABELA + " where " +
                Banco.EMAIL + " =?";
        Cursor cursor = null;
        if(db != null){
            cursor = db.rawQuery(query, new String[]{
                    email
            });
        }
        return cursor.getCount() > 0;
    }

    public int retornoCadastrado(String email, String senha){
        SQLiteDatabase db = this.getReadableDatabase();
        String query = "Select * from " + Banco.TABELA + " where " +
                Banco.EMAIL + " =? " + " AND " + Banco.SENHA + " =? ";
        Cursor cursor = null;
        if(db != null)
            cursor = db.rawQuery(query, new String[]{
                    email,senha
            });
        if(cursor != null)
            cursor.moveToFirst();

        return (cursor.getCount() > 0) ? cursor.getInt(0) : 0;
    } */
}
