import { Component, OnInit } from '@angular/core';
import axios from 'axios';
import { Router } from '@angular/router';

interface QuestionItem {
  questionId: number;
  questionTitle: string;
  questionText: string;
  status: 'Pending'|'Approved'|'Rejected';
  createdAt: string;
  username: string;
  imagePaths?: string[];
}

@Component({
  selector: 'app-approve-questions',
  standalone: false,
  templateUrl: './approve-questions.html',
  styleUrl: './approve-questions.css'
})
export class ApproveQuestions implements OnInit {
  
  items: QuestionItem[] = [];
  filtered: QuestionItem[] = [];
  search = '';
  filterStatus: 'Pending'|'Approved'|'Rejected'|'All' = 'Pending';

  private api = axios.create({ baseURL: 'http://localhost:5081/api' });

  constructor(private router: Router) {
    this.api.interceptors.request.use(config => {
      const t = localStorage.getItem('authToken');
      if (t) config.headers.Authorization = `Bearer ${t}`;
      return config;
    });
  }

  ngOnInit(): void { this.reload(); }

  async reload() {
    // TODO: change to your Questions endpoint returning DTO (with imagePaths)
    const res = await this.api.get<QuestionItem[]>('/QuestionApi');
    this.items = res.data;
    this.filter();
  }

  filter() {
    const s = this.search.toLowerCase();
    this.filtered = this.items.filter(q => {
      const matchStatus = this.filterStatus === 'All' || q.status === this.filterStatus;
      const matchSearch =
         q.questionTitle.toLowerCase().includes(s) ||
         q.questionText.toLowerCase().includes(s) ||
         q.username.toLowerCase().includes(s);
      return matchStatus && matchSearch;
    });
  }

  async approve(id: number) {
    await this.api.put(`/QuestionApi/${id}/approve`);
    await this.reload();
  }

  async reject(id: number) {
    await this.api.put(`/QuestionApi/${id}/reject`);
    await this.reload();
  }

  logout() {
    localStorage.removeItem('authToken');
    this.router.navigateByUrl('/');
  }
}
