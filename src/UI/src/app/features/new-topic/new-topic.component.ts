import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, input, OnInit, Output, ViewChild } from '@angular/core';
import { ITopic } from '../models/topic.model';
import { TopicsService } from '../services/topics.service';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import { MatMenu } from '@angular/material/menu';
import { CdkMenuTrigger } from '@angular/cdk/menu';

@Component({
  selector: 'app-new-topic',
  standalone: true,
  imports: [CommonModule, FormsModule, MatFormFieldModule, MatInputModule],
  templateUrl: './new-topic.component.html',
  styleUrl: './new-topic.component.scss'
})
export class NewTopicComponent{

  @Output() addEvent = new EventEmitter<ITopic>();

  showError : boolean = false;
  value : ITopic = {
    id : 0,
    by : "",
    title : "",
    type : "",
    url : "",
    score : 0
  }
  
  constructor(private topicsService : TopicsService){}

  create(){
    this.topicsService
      .add(this.value)
      .subscribe({
        next: (data) => {
          this.addEvent.emit(data);
          this.showError = false;
        },
        error: () => {
          this.showError = true;
        }
      })
  }
}
