import { Component } from '@angular/core';
import { Producto } from './models/producto';
import { ProductoService } from './services/producto.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  producto: Producto = {
    idProducto:  0,
    nombre:      "",
    descripcion: "",
    precio:      "",
    fecha:       new Date(),
    stock:       ""
  };
  datatable: any = [];

  constructor(private productoService: ProductoService){

  }

  ngOnInit(): void {
    this.onDataTable();
  }

  onDataTable(){
    this.productoService.getProducto().subscribe(resultado =>{
        this.datatable = resultado;
        console.log(resultado);
    });
  }

  onAddProductos(producto: Producto): void{
    this.productoService.addProducto(producto).subscribe(respuesta =>{
      if(respuesta){
        alert("Producto registrado!");
        this.clear();
        this.onDataTable();
      } else {
        alert("Error al registrar producto!");
      }
    });
  }

  onUpdateProductos(producto: Producto): void {
    this.productoService.updateProducto(producto.idProducto , producto).subscribe(respuesta => {
      if(respuesta){
        alert("Producto actualizado!");
        this.clear();
        this.onDataTable();
      } else {
        alert("Error al actualizar producto!");
      }
    });
  }

  onDeleteProductos(id: number): void {
    this.productoService.deleteProducto(id).subscribe(respuesta =>{
      if(respuesta){
        alert("Producto eliminado!");
        this.clear();
        this.onDataTable();
      } else {
        alert("Error al eliminar producto!");
      }
    });
  }

  onSetData(select: any){
    this.producto.idProducto = select.idProducto;
    this.producto.nombre = select.nombre;
    this.producto.descripcion = select.descripcion;
    this.producto.precio = select.precio;
  }


  clear(){
    this.producto.idProducto = 0;
    this.producto.nombre = "";
    this.producto.descripcion = "";
    this.producto.precio = "";
  }
}
