import { Component, OnInit } from '@angular/core';
import { ValueService } from '../../../core/services/value.service';
import { from } from 'rxjs';

@Component({
  selector: 'app-home',
  templateUrl: '../home/home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  private data: any;
  constructor(private valueService: ValueService) { }

  ngOnInit() {
    this.GetAllValues();
  }

  private GetAllValues(): void {
    this.valueService.getAll().subscribe(
      sucess => {
        console.log(sucess);

        return this.data = sucess;
      });
  }
}




