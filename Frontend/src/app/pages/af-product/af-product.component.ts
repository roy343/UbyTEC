import { Component, OnInit } from '@angular/core';
import { APICommunicationService } from 'src/app/apicommunication.service';
import { StorageService } from 'src/app/storage.service';
import { ActivatedRoute, Router } from '@angular/router';



@Component({
  selector: 'app-af-product',
  templateUrl: './af-product.component.html',
  styleUrls: ['./af-product.component.scss']
})
export class AfProductComponent implements OnInit {
  products = [];

  constructor(private backend: APICommunicationService,  private localStorage: StorageService) { }

  ngOnInit(): void {
    this.backend.getProductbyID(1111).subscribe(
      response => {
        this.localStorage.saveData('products', JSON.stringify(response))
      }
    )
    this.products = JSON.parse(this.localStorage.getData('products'))
  }

  deleteProduct(id: any ){
    this.backend.deleteProduct(id).subscribe(data => {
       console.log('Eliminado correctamente')
    })
  }

}