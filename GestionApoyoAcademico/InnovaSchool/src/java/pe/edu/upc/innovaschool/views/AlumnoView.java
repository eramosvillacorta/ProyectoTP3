/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pe.edu.upc.innovaschool.views;



/**
 *
 * @author PhILiPp
 */

public class AlumnoView {
    private int idPersona;
    private String nombre;
    private String apellidoPaterno;
    private String apellidoMaterno;
    private String direccion;    
    private String parentesco;
    private String genero;
    private String idGrado;
    private String fechaNacimiento;
    private int tipDocIde;
    private String nroDocIde;

    public int getIdPersona() {
        return idPersona;
    }

    public void setIdPersona(int idPersona) {
        this.idPersona = idPersona;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public String getApellidoPaterno() {
        return apellidoPaterno;
    }

    public void setApellidoPaterno(String apellidoPaterno) {
        this.apellidoPaterno = apellidoPaterno;
    }

    public String getApellidoMaterno() {
        return apellidoMaterno;
    }

    public void setApellidoMaterno(String apellidoMaterno) {
        this.apellidoMaterno = apellidoMaterno;
    }

    public String getDireccion() {
        return direccion;
    }

    public void setDireccion(String direccion) {
        this.direccion = direccion;
    }

    public String getParentesco() {
        return parentesco;
    }

    public void setParentesco(String parentesco) {
        this.parentesco = parentesco;
    }

    public String getGenero() {
        return genero;
    }

    public void setGenero(String genero) {
        this.genero = genero;
    }

    public String getIdGrado() {
        return idGrado;
    }

    public void setIdGrado(String idGrado) {
        this.idGrado = idGrado;
    }

    public String getFechaNacimiento() {
        return fechaNacimiento;
    }

    public void setFechaNacimiento(String fechaNacimiento) {
        this.fechaNacimiento = fechaNacimiento;
    }

    public int getTipDocIde() {
        return tipDocIde;
    }

    public void setTipDocIde(int tipDocIde) {
        this.tipDocIde = tipDocIde;
    }

    public String getNroDocIde() {
        return nroDocIde;
    }

    public void setNroDocIde(String nroDocIde) {
        this.nroDocIde = nroDocIde;
    }
    
}
