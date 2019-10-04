import { Component, OnInit, OnDestroy, OnChanges } from '@angular/core';
import { AppService } from './app.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit, OnDestroy, OnChanges {
  title = 'New-Food';
  constructor(private appService: AppService) {

  }
  ngOnInit() {
    //this. getData();
  }
  ngOnDestroy() {
    ''
  }
  ngOnChanges() {
    // lay tat ca nhung cai thay doi.
    // ko phai thay doi tat ca
  }
  // getData() {
  //   this.appService.getData().subscribe(respon => {
  //     console.log('ress', respon);
  //   });
  //   setTimeout(() => {
  //     this.appService.getDataWithId(1).subscribe(xx => {
  //       console.log(' ID', xx);
  //     });
  //   }, 2000);
  // }
}