import { Component, OnInit, ViewChild } from '@angular/core';
import { TopicsService } from '../services/topics.service';
import { ITopic } from '../models/topic.model';
import { CommonModule } from '@angular/common';
import {MatTableModule} from '@angular/material/table';
import { NewTopicComponent } from "../new-topic/new-topic.component";
import { MatButtonModule } from '@angular/material/button';
import { FormsModule } from '@angular/forms';
import { CdkMenuTrigger, CdkMenu, CdkMenuItem } from '@angular/cdk/menu';
import {MatMenuModule} from '@angular/material/menu';
import { RouterOutlet, RouterLink } from '@angular/router';
import { finalize } from 'rxjs';

@Component({
  selector: 'app-topics',
  standalone: true,
  imports: [CommonModule, 
    MatTableModule, 
    NewTopicComponent,
    CdkMenuTrigger,
    MatButtonModule,
    FormsModule,
    MatMenuModule,
    CdkMenuItem,
    RouterOutlet, 
    RouterLink],
  templateUrl: './topics.component.html',
  styleUrl: './topics.component.scss'
})
export class TopicsComponent implements OnInit {

  isLoad : boolean ;
  showError : boolean;
  topics : ITopic[] = [];
  displayedColumns: string[] = ['title', 'score'];

  constructor(private topicsService : TopicsService){
    this.isLoad = false;
    this.showError = false;
  }
  @ViewChild(CdkMenuTrigger) newTopicWindowTrigger! : CdkMenuTrigger;

  ngOnInit(): void {
    this.loadTopics();
  }

  addNewTopic(topic : ITopic){
    this.topics.push(topic);
    this.newTopicWindowTrigger.close();
  }

  private loadTopics(){
    this.isLoad = true;
    this.topics = [];
    
    this.topicsService
      .getAll()
      .pipe(
        finalize(() => this.isLoad = false)
      )
      .subscribe({
        next : result => {
          this.topics = result;
          this.showError = false;
        },
        error : () => {
          this.showError = true;
        }
      })
  }
}
