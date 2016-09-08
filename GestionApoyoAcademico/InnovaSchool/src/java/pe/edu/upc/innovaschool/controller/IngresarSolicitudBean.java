/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pe.edu.upc.innovaschool.controller;

import javax.inject.Named;
import javax.enterprise.context.SessionScoped;
import java.io.Serializable;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import javax.faces.event.AjaxBehaviorEvent;
import pe.edu.upc.innovaschool.dao.IngresarSolicitudDAO;
import pe.edu.upc.innovaschool.views.AlumnoView;
import pe.edu.upc.innovaschool.views.ApoderadoView;

/**
 *
 * @author PhILiPp
 */
@Named(value = "ingresarSolicitudBean")
@SessionScoped
public class IngresarSolicitudBean implements Serializable {
    private ApoderadoView apoderado;
    private AlumnoView alumno;
    private List<AlumnoView> alumnos;
    
    private static Map<String,Object> getCbxSedes;
    static{
        getCbxSedes = new LinkedHashMap<String,Object>();
        IngresarSolicitudDAO sol = new IngresarSolicitudDAO();
        ArrayList sedesList = (ArrayList) sol.getSedes();
        Iterator i = sedesList.iterator();
        
        while (i.hasNext()) {
            
            Object[] element = (Object[]) i.next();
            getCbxSedes.put(String.valueOf(element[1]), String.valueOf(element[0]));
        }
       
    }
    public Map<String, Object> getGetCbxSedes(){
        return getCbxSedes;
    }
    /**
     * Creates a new instance of IngresarSolicitudBean
     */
    public IngresarSolicitudBean() {
    }
    
    private static Map<String,Object> getCbxGrados;
    static{
        getCbxGrados = new LinkedHashMap<String,Object>();
        IngresarSolicitudDAO sol = new IngresarSolicitudDAO();
        ArrayList sedesList = (ArrayList) sol.getGrados();
        Iterator i = sedesList.iterator();
        
        while (i.hasNext()) {
            
            Object[] element = (Object[]) i.next();
            getCbxGrados.put(String.valueOf(element[1]), String.valueOf(element[0]));
        }
       
    }
    public Map<String, Object> getCbxGrados(){
        return getCbxGrados;
    }
    
    private static Map<String,Object> getCbxTipDoc;
    static{
        getCbxTipDoc = new LinkedHashMap<String,Object>();
        IngresarSolicitudDAO sol = new IngresarSolicitudDAO();
        ArrayList sedesList = (ArrayList) sol.getTipoDocIden();
        Iterator i = sedesList.iterator();
        
        while (i.hasNext()) {
            
            Object[] element = (Object[]) i.next();
            getCbxTipDoc.put(String.valueOf(element[1]), String.valueOf(element[0]));
        }
       
    }
    public Map<String, Object> getCbxTipDoc(){
        return getCbxTipDoc;
    }

    public ApoderadoView getApoderado() {
        return apoderado;
    }

    public void setApoderado(ApoderadoView apoderado) {
        this.apoderado = apoderado;
    }

    public AlumnoView getAlumno() {
        return alumno;
    }

    public void setAlumno(AlumnoView alumno) {
        this.alumno = alumno;
    }

    public List<AlumnoView> getAlumnos() {
        return alumnos;
    }

    public void setAlumnos(List<AlumnoView> alumnos) {
        this.alumnos = alumnos;
    }
    
    public void addAlumnosGrid (AjaxBehaviorEvent p_oEvent){
        alumnos.add(getAlumno());
    }
}
