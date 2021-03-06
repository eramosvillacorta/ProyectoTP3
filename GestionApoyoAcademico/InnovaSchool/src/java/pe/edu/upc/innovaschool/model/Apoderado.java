package pe.edu.upc.innovaschool.model;
// Generated 06-sep-2016 10:42:15 by Hibernate Tools 4.3.1


import java.util.HashSet;
import java.util.Set;

/**
 * Apoderado generated by hbm2java
 */
public class Apoderado  implements java.io.Serializable {


     private int idApoderado;
     private Persona persona;
     private String parentesco;
     private String email;
     private String telefono2;
     private Set alumnos = new HashSet(0);

    public Apoderado() {
    }

	
    public Apoderado(int idApoderado) {
        this.idApoderado = idApoderado;
    }
    public Apoderado(int idApoderado, Persona persona, String parentesco, String email, String telefono2, Set alumnos) {
       this.idApoderado = idApoderado;
       this.persona = persona;
       this.parentesco = parentesco;
       this.email = email;
       this.telefono2 = telefono2;
       this.alumnos = alumnos;
    }
   
    public int getIdApoderado() {
        return this.idApoderado;
    }
    
    public void setIdApoderado(int idApoderado) {
        this.idApoderado = idApoderado;
    }
    public Persona getPersona() {
        return this.persona;
    }
    
    public void setPersona(Persona persona) {
        this.persona = persona;
    }
    public String getParentesco() {
        return this.parentesco;
    }
    
    public void setParentesco(String parentesco) {
        this.parentesco = parentesco;
    }
    public String getEmail() {
        return this.email;
    }
    
    public void setEmail(String email) {
        this.email = email;
    }
    public String getTelefono2() {
        return this.telefono2;
    }
    
    public void setTelefono2(String telefono2) {
        this.telefono2 = telefono2;
    }
    public Set getAlumnos() {
        return this.alumnos;
    }
    
    public void setAlumnos(Set alumnos) {
        this.alumnos = alumnos;
    }




}


