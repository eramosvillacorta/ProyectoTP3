/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pe.edu.upc.innovaschool.views;

import java.io.Serializable;
import javax.enterprise.context.SessionScoped;


/**
 *
 * @author PhILiPp
 */
@SessionScoped
public class ApoderadoView implements Serializable{
    private int idPersona;
    private String nombre;
    private String apellidoPaterno;
    private String apellidoMaterno;
    private String direccion;
    private String telefono;
    private String telefonoEmer;
    private String parentesco;
    private String genero;
    private String email;
    private int tipDocIde;
    private String nroDocIde;
    private int idSede;

    public int getIdSede() {
        return idSede;
    }

    public void setIdSede(int idSede) {
        this.idSede = idSede;
    }

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

    public String getTelefono() {
        return telefono;
    }

    public void setTelefono(String telefono) {
        this.telefono = telefono;
    }

    public String getParentesco() {
        return parentesco;
    }

    public void setParentesco(String parentesco) {
        this.parentesco = parentesco;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
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
    
    public String getGenero() {
        return genero;
    }

    public void setGenero(String genero) {
        this.genero = genero;
    }

    public String getTelefonoEmer() {
        return telefonoEmer;
    }

    public void setTelefonoEmer(String telefonoEmer) {
        this.telefonoEmer = telefonoEmer;
    }
    
}
