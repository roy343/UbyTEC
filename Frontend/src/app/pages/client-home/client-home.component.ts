import { Component, OnInit } from '@angular/core';
import { APICommunicationService } from 'src/app/apicommunication.service';
import { StorageService } from 'src/app/storage.service';
import { ActivatedRoute, Router} from '@angular/router';

@Component({
  selector: 'app-client-home',
  templateUrl: './client-home.component.html',
  styleUrls: ['./client-home.component.scss']
})
export class ClientHomeComponent implements OnInit {

  stores = [];
  constructor(private backend: APICommunicationService,  private localStorage: StorageService, private router: Router) { }

  ngOnInit(): void {
    this.backend.getStores().subscribe(
      response => {
        this.localStorage.saveData('stores', JSON.stringify(response))
      }
    )
    this.stores = JSON.parse(this.localStorage.getData('stores'))

  }

  openShop(id: number){
    this.router.navigate([`/store/${id}`])
  }

}
