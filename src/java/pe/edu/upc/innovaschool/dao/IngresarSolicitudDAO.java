/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pe.edu.upc.innovaschool.dao;

import java.util.List;
import org.hibernate.SQLQuery;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import pe.edu.upc.innovaschool.util.HibernateUtil;

/**
 *
 * @author PhILiPp
 */
public class IngresarSolicitudDAO {
    

    public List getSedes() {
        SessionFactory sesFact = HibernateUtil.getSessionFactory();
        Session ses = sesFact.openSession();
        
        String hsql= "SELECT S.idSede, S.descripcion FROM gaa.Sede S";
        SQLQuery sql = ses.createSQLQuery(hsql);
        List listaResultado = sql.list();        
        ses.close();
        return listaResultado;
    }
    
    public List getGrados(){
        SessionFactory sesFact = HibernateUtil.getSessionFactory();
        Session ses= sesFact.openSession();
        
        String hsql="SELECT G.IdGrado,G.Descripcion FROM gp.Grado G";
        SQLQuery sql= ses.createSQLQuery(hsql);
        
        List listaResultado = sql.list();
        ses.close();
        return listaResultado;
    }
    
    public List getTipoDocIden(){
        SessionFactory sesFact = HibernateUtil.getSessionFactory();
        Session ses= sesFact.openSession();
        
        String hsql="SELECT DI.idDocumentoIdentidad,DI.descripcion FROM gaa.DocumentoIdentidad DI";
        SQLQuery sql= ses.createSQLQuery(hsql);
        
        List listaResultado = sql.list();
        ses.close();
        return listaResultado;
    }
}
