package com.example.homemove;

import android.content.ContentValues;
import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

import androidx.annotation.Nullable;

public class Banco extends SQLiteOpenHelper{
    public static final String NOME_DB = "dbFilme";
    public static final String TABELA_USU = "usuario";
    public static final String ID_USU = "idUso";
    public static final String NOME_USO = "nome";
    public static final String LOGIN_USO = "email";
    public static final String SENHA_USO = "senha";

    public Banco(Context context) {
        super(context, NOME_DB, null, 1);
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        db.execSQL("CREATE TABLE " + TABELA_USU + "("
                        + ID_USU + "interger primary key,"
                        + NOME_USO + "text,"
                        + LOGIN_USO + "text,"
                        + SENHA_USO + "text" +
                ")"
        );
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        db.execSQL("DROP TABLE IF EXISTS " + TABELA_USU);
    }

    public boolean insertUsuario(@Nullable Controller controller){
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues contentValues = new ContentValues();

        contentValues.put(NOME_USO, controller.getNome());
        contentValues.put(LOGIN_USO, controller.getLogin());
        contentValues.put(SENHA_USO, controller.getSenha());

        return  db.insert(TABELA_USU, null, contentValues) > 0;
    }
}
