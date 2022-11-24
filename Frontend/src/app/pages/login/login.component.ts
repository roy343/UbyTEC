import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { APICommunicationService } from 'src/app/apicommunication.service';
import { StorageService } from 'src/app/storage.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit, OnDestroy {
  constructor(private localStorage: StorageService, private router: Router, private api: APICommunicationService) {}

  username: string = '';
  password: string = '';
  errorState: boolean = false;
  errorMsg: string = '';


  ngOnInit() {
  }
  ngOnDestroy() {
  }

  handleLogin() {
    
    this.api.getEmployeebyUsername(this.username).subscribe(
      (data : Object) => {
        data['admin'] = true;
        
        if(this.password !== data['password']){
          this.errorState = true
          this.errorMsg = 'Email or password incorrect!'
          console.log(this.errorMsg)
          return
        }
        
        this.localStorage.saveData('user', JSON.stringify(data))
        this.router.navigate(['/dashboard'])
        console.log("gucci")

        return
      }, (error => {
        if (error.status === 404) {
          this.errorState = true
          this.errorMsg = 'Email or password incorrect!'
        }
      })
    )
    this.api.getAffiliatebyEmail(this.username).subscribe(
      (data: Object) => {
        data['admin'] = false;

        if (this.password !== data['password']) {
          this.errorState = true
          this.errorMsg = 'Email or password incorrect!'
          return
        }
        
        this.localStorage.saveData('user', JSON.stringify(data))
        this.router.navigate(['/dashboard'])
        console.log("gucci")
        return
      }, (error => {
        if(error.status === 404){
          this.errorState = true
          this.errorMsg = 'Email or password incorrect!'
        }
        
      })

    )
    this.api.getClientbyEmail(this.username).subscribe(
      (data: Object) => {
        data['admin'] = false;

        if (this.password !== data['password']) {
          this.errorState = true
          this.errorMsg = 'Email or password incorrect!'
          return
        }
        
        this.localStorage.saveData('user', JSON.stringify(data))
        this.router.navigate(['/dashboard'])
        
        console.log("gucci")
        return
      }, (error => {
        if(error.status === 404){
          this.errorState = true
          this.errorMsg = 'Email or password incorrect!'
        }
        
      })

    )

    
    
    return
  }

}
