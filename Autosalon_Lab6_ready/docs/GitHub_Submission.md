# Інструкція здачі на GitHub

## Важливо
За вимогами лабораторної роботи результатом має бути GitHub-репозиторій та звіт.

## Рекомендований порядок комітів

```bash
git init
git add README.md src/Autosalon_Lab6.csproj
git commit -m "Create project structure"

git add src/Program.cs
git commit -m "Add base Vehicle hierarchy"

git add src/Program.cs
git commit -m "Add individual PublicTransport hierarchy"

git add docs
git commit -m "Add report and documentation"
```

## Завантаження на GitHub

```bash
git branch -M main
git remote add origin https://github.com/USERNAME/Autosalon_Lab6.git
git push -u origin main
```

Після цього потрібно вставити посилання на репозиторій у звіт.
