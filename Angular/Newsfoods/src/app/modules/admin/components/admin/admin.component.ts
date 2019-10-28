import { Component, OnInit } from '@angular/core';
import { ValueService } from '../../../../core/services/value.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent implements OnInit {
  private data: any;
  constructor(
    private value: ValueService) { }

  ngOnInit() {
    return this.value.getAll().subscribe(
      res => {
        this.data = res;
      })
  }
}
