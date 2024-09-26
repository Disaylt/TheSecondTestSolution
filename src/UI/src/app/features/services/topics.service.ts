import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ITopic } from '../models/topic.model';

@Injectable({
  providedIn: 'root'
})
export class TopicsService {

  constructor(private httpClient : HttpClient) { }

  getAll(){
    const path = "api/topics"

    return this.httpClient.get<ITopic[]>(path);
  }

  getById(id : number){
    const path = `api/topic/${id}`;

    return this.httpClient.get<ITopic>(path);
  }

  add(topic : ITopic){
    const path = "api/topic"

    return this.httpClient.post<ITopic>(path, topic);
  }
}
