import { Component, OnInit } from '@angular/core';
import { StatModel } from '../models/statModel';
@Component({
  selector: 'app-mini-stats',
  templateUrl: './mini-stats.component.html',
  styleUrls: ['./mini-stats.component.css']
})
export class MiniStatsComponent implements OnInit {

  stat: StatModel = {
    id: 1,
    title: 'Bitcoin',
    amount: 10,
    listPrice: 1000.50,
    totalValue: 10000.50,
    change: 10.1,
  };

  constructor() { }

  ngOnInit() {
  }

}
