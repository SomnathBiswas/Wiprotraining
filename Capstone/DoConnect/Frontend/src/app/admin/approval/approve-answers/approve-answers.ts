import { Component, OnInit } from '@angular/core';
import axios from 'axios';
import { Router } from '@angular/router';

interface AnswerItem {
  answerId: number;
  questionId: number;
  questionTitle: string;
  answerText: string;
  status: 'Pending'|'Approved'|'Rejected';
  createdAt: string;
  username: string;
  imagePaths?: string[];
}

@Component({
  selector: 'app-approve-answers',
  standalone: false,
  templateUrl: './approve-answers.html',
  styleUrl: './approve-answers.css'
})
export class ApproveAnswers {
  items: AnswerItem[] = [];
  filtered: AnswerItem[] = [];
  search = '';
  filterStatus: 'Pending'|'Approved'|'Rejected'|'All' = 'Pending';

  private api = axios.create({ baseURL: 'http://localhost:5081/api' });

  constructor(private router: Router) {
    this.api.interceptors.request.use(c => {
      const t = localStorage.getItem('authToken');
      if (t) c.headers.Authorization = `Bearer ${t}`;
      return c;
    });
  }

  ngOnInit(): void { this.reload(); }

  async reload() {
    // TODO: Replace with your answers endpoint (Pending/All)
    const res = await this.api.get<AnswerItem[]>('/AnswerApi');
    this.items = res.data;
    this.filter();
  }

  filter() {
    const s = this.search.toLowerCase();
    this.filtered = this.items.filter(a => {
      const st = this.filterStatus === 'All' || a.status === this.filterStatus;
      const se = a.answerText.toLowerCase().includes(s) ||
                 a.username.toLowerCase().includes(s) ||
                 a.questionTitle?.toLowerCase().includes(s);
      return st && se;
    });
  }

  async approve(id: number) {
    await this.api.put(`/AnswerApi/${id}/approve`);
    await this.reload();
  }
  async reject(id: number) {
    await this.api.put(`/AnswerApi/${id}/reject`);
    await this.reload();
  }

  logout() {
    localStorage.removeItem('authToken');
    this.router.navigateByUrl('/');
  }
}
