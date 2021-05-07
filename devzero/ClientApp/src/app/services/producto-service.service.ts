import { Inject, Injectable } from '@angular/core';
import {HttpHeaders, HttpClient} from "@angular/common/http";
import { Observable } from 'rxjs';
import { Producto } from '../Models/producto';
import {tap} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ProductoServiceService {
  ruta: String="";
  constructor( private http:HttpClient, @Inject('BASE_URL') baseUrl:String) {
    this.ruta=baseUrl;
   }

  post(producto : Producto) : Observable<Producto>{
    return this.http.post(this.ruta+"api/Persona",producto).pipe(tap(()=>console.log("Se ha registrado")))
  }
}
