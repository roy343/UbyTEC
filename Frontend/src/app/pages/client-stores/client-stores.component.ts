import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router} from '@angular/router';
import { APICommunicationService } from 'src/app/apicommunication.service';
import { StorageService } from 'src/app/storage.service';

@Component({
  selector: 'app-client-stores',
  templateUrl: './client-stores.component.html',
  styleUrls: ['./client-stores.component.scss']
})
export class ClientStoresComponent implements OnInit {
  products = [];

  constructor(private backend: APICommunicationService,  private localStorage: StorageService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    let routeParams = this.route.snapshot.paramMap;
    let storeID = Number(routeParams.get('storeID'));
    this.backend.getProductbyID(storeID).subscribe(
      response => {
        this.localStorage.saveData('products', JSON.stringify(response))
      }
    )
    this.products = JSON.parse(this.localStorage.getData('products'))
    console.warn(storeID)
  }

}
