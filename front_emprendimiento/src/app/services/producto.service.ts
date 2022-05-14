import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http'
import { Producto } from '../models/producto';
import { catchError, map, Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductoService {

  constructor(private http: HttpClient) { }

  url: string = "https://localhost:44300/api/Productos";

  getProducto(){
    return this.http.get(this.url);
  }

  addProducto(producto: Producto): Observable<Producto>{
    return this.http.post<Producto>(this.url, producto);
  }

  updateProducto(id: number, producto: Producto): Observable<Producto>{
    const url = `${this.url}/${id}`;
    console.log(id, producto);
    return this.http.put<Producto>(url, producto);
  }

  deleteProducto(id: number){
    return this.http.delete(this.url + `/${id}`);
  }
}
