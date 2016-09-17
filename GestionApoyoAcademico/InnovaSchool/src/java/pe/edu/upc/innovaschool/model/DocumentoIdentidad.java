package pe.edu.upc.innovaschool.model;
// Generated 06-sep-2016 10:42:15 by Hibernate Tools 4.3.1


import java.util.HashSet;
import java.util.Set;

/**
 * DocumentoIdentidad generated by hbm2java
 */
public class DocumentoIdentidad  implements java.io.Serializable {


     private int idDocumentoIdentidad;
     private String descripcion;
     private Set personas = new HashSet(0);

    public DocumentoIdentidad() {
    }

	
    public DocumentoIdentidad(int idDocumentoIdentidad) {
        this.idDocumentoIdentidad = idDocumentoIdentidad;
    }
    public DocumentoIdentidad(int idDocumentoIdentidad, String descripcion, Set personas) {
       this.idDocumentoIdentidad = idDocumentoIdentidad;
       this.descripcion = descripcion;
       this.personas = personas;
    }
   
    public int getIdDocumentoIdentidad() {
        return this.idDocumentoIdentidad;
    }
    
    public void setIdDocumentoIdentidad(int idDocumentoIdentidad) {
        this.idDocumentoIdentidad = idDocumentoIdentidad;
    }
    public String getDescripcion() {
        return this.descripcion;
    }
    
    public void setDescripcion(String descripcion) {
        this.descripcion = descripcion;
    }
    public Set getPersonas() {
        return this.personas;
    }
    
    public void setPersonas(Set personas) {
        this.personas = personas;
    }




}

