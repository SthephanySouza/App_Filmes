package com.example.appfilmes.banco;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;

import com.example.appfilmes.banco.Banco;

public class BancoController {
    private SQLiteDatabase db;
    private Banco banco;

    public BancoController(Context context){
        banco = new Banco(context);
    }

    public String insertFilme(String filme, String classific, String dataLanc, String idioma, String genero){
        ContentValues valores;
        long resultado;

        db = banco.getWritableDatabase();
        valores = new ContentValues();
        valores.put(Banco.NOME_FILME, filme);
        valores.put(Banco.CLASSIFIC, classific);
        valores.put(Banco.GENERO, genero);
        valores.put(Banco.DATA_LANC, dataLanc);
        valores.put(Banco.IDIOMA, idioma);

        resultado = db.insert(Banco.TABELA_FILME, null, valores);
        db.close();

        if (resultado ==-1){
            return "Erro ao inserir filme";
        }
        else{
            return "Filme Inserido com sucesso";
        }
    }

    public Cursor Carregar(){
        Cursor cursor;
        String[] campos =  {banco.ID_FILME,banco.NOME_FILME};
        db = banco.getReadableDatabase();
        cursor = db.query(banco.TABELA, campos, null, null, null, null, null, null);

        if(cursor!=null){
            cursor.moveToFirst();
        }
        db.close();
        return cursor;
    }
    public Cursor CarregaId(int idFilme){
        Cursor cursor;
        String[] campos =  {banco.ID_FILME,banco.NOME_FILME,banco.CLASSIFIC,banco.DATA_LANC,banco.IDIOMA,banco.GENERO};
        String where = Banco.ID_FILME + "=" + idFilme;
        db = banco.getReadableDatabase();
        cursor = db.query(Banco.TABELA,campos,where, null, null, null, null, null);

        if(cursor!=null){
            cursor.moveToFirst();
        }
        db.close();
        return cursor;
    }

    public void Alterar(int idFilme, String nomeFilme, String classific, String dataLanc, String idioma, String genero){
        ContentValues valores;
        String where;

        db = banco.getWritableDatabase();

        where = Banco.ID_FILME + "=" + idFilme;

        valores = new ContentValues();
        valores.put(Banco.NOME_FILME, nomeFilme);
        valores.put(Banco.CLASSIFIC, classific);
            valores.put(Banco.GENERO, genero);
        valores.put(Banco.DATA_LANC, dataLanc);
        valores.put(Banco.IDIOMA, idioma);

        db.update(Banco.TABELA,valores,where,null);
        db.close();
    }

    public void Deletar(int idFilme){
        String where = Banco.ID_FILME + "=" + idFilme;
        db = banco.getReadableDatabase();
        db.delete(Banco.TABELA,where,null);
        db.close();
    }

    public String insertGenero(String filme, String genero){
        ContentValues valores;
        long resultado;

        db = banco.getWritableDatabase();
        valores = new ContentValues();
        valores.put(Banco.NOME_FILME, filme);
        valores.put(Banco.GENERO, genero);

        resultado = db.insert(Banco.TABELA_FILME, null, valores);
        db.close();

        if (resultado ==-1){
            return "Erro ao inserir gênero";
        }
        else{
            return "Gênero inserido com sucesso";
        }
    }

    public Cursor BuscaId(int idFilme){
        Cursor cursor;
        String[] campos =  {banco.ID_FILME,banco.NOME_FILME,banco.GENERO};
        String where = Banco.ID_FILME + "=" + idFilme;
        db = banco.getReadableDatabase();
        cursor = db.query(Banco.TABELA,campos,where, null, null, null, null, null);

        if(cursor!=null){
            cursor.moveToFirst();
        }
        db.close();
        return cursor;
    }

    public void Update(int idFilme, String nomeFilme, String genero){
        ContentValues valores;
        String where;

        db = banco.getWritableDatabase();

        where = Banco.ID_FILME + "=" + idFilme;

        valores = new ContentValues();
        valores.put(Banco.NOME_FILME, nomeFilme);
        valores.put(Banco.GENERO, genero);

        db.update(Banco.TABELA,valores,where,null);
        db.close();
    }

    public void Delet(int idFilme){
        String where = Banco.ID_FILME + "=" + idFilme;
        db = banco.getReadableDatabase();
        db.delete(Banco.TABELA,where,null);
        db.close();
    }
}
