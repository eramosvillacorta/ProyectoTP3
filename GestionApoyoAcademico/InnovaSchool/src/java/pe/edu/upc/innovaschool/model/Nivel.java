package pe.edu.upc.innovaschool.model;
// Generated 06-sep-2016 10:42:15 by Hibernate Tools 4.3.1


import java.util.HashSet;
import java.util.Set;

/**
 * Nivel generated by hbm2java
 */
public class Nivel  implements java.io.Serializable {


     private int idNivel;
     private String nombre;
     private String descripcion;
     private Set grados = new HashSet(0);

    public Nivel() {
    }

	
    public Nivel(int idNivel, String nombre) {
        this.idNivel = idNivel;
        this.nombre = nombre;
    }
    public Nivel(int idNivel, String nombre, String descripcion, Set grados) {
       this.idNivel = idNivel;
       this.nombre = nombre;
       this.descripcion = descripcion;
       this.grados = grados;
    }
   
    public int getIdNivel() {
        return this.idNivel;
    }
    
    public void setIdNivel(int idNivel) {
        this.idNivel = idNivel;
    }
    public String getNombre() {
        return this.nombre;
    }
    
    public void setNombre(String nombre) {
        this.nombre = nombre;
    }
    public String getDescripcion() {
        return this.descripcion;
    }
    
    public void setDescripcion(String descripcion) {
        this.descripcion = descripcion;
    }
    public Set getGrados() {
        return this.grados;
    }
    
    public void setGrados(Set grados) {
        this.grados = grados;
    }




}


