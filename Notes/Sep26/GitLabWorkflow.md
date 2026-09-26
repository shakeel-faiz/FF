# GitLab Tested Workflow - Upgraded

Just give the commit id of the grandest parent and all will be done automatically

```
function Set-GitCommitDateById2 ($id, $dt) {
    # Date ko sahi format mein lana
    $formattedDate = (Get-Date $dt).ToString("yyyy-MM-dd HH:mm:ss")
    # Pura Commit Hash nikalna
    $fullCommitId = (git rev-parse $id).Trim()

    # Sirf filter-branch ke andar hi env variables ka istemal karein
    git filter-branch --env-filter "if [ `$GIT_COMMIT = '$fullCommitId' ]; then export GIT_AUTHOR_DATE='$formattedDate'; export GIT_COMMITTER_DATE='$formattedDate'; fi" --force

    # Purana backup clear karna taake agli baar error na aaye
    git update-ref -d refs/original/refs/heads/master 2>$null
    Write-Host "Kamyabi se date badal gayi hai!" -ForegroundColor Green
}

Set-GitCommitDateById2 "935b186f357ce15cd256c0eb6343956ccc618014" "2026-09-21T09:11:21"
```


# GitLab Tested Workflow - OutDated

Always commit like this with past dates

```
GIT_AUTHOR_DATE="2026-09-22T16:25:02" GIT_COMMITTER_DATE="2026-09-22T16:25:02" git commit -m "refactor: restructure logging configuration and add diagnostic comments

- Add commented JSON log output example for ContentActionsController error messages  
- Configure Console with JSON formatter and indented output for structured logging"
```

Once, your branch is ready, rebase the parent root commit like this

```
git rebase -i HEAD~20 --committer-date-is-author-date
```

You will edit it and then run this command

```
git commit --amend

git rebase –continue
```

Now all above commits will be new, but parent most commit commiter date is set today, you need to reset it to previous author date

You will use this powershell function

```
function Set-GitCommitDateById ($id, $dt) {
    $formattedDate = (Get-Date $dt).ToString("yyyy-MM-dd HH:mm:ss")
    $fullCommitId = (git rev-parse $id).Trim()
    $env:GIT_COMMITTER_DATE = $formattedDate

    git filter-branch --env-filter "if [ `$GIT_COMMIT = '$fullCommitId' ]; then export GIT_AUTHOR_DATE='$formattedDate'; export GIT_COMMITTER_DATE='$formattedDate'; fi" --force

    Remove-Item Env:\GIT_COMMITTER_DATE
    git update-ref -d refs/original/refs/heads/master 2>$null
    Write-Host "Kamyabi se date badal gayi hai!" -ForegroundColor Green
}


Set-GitCommitDateById "f759456a6660729ad34263016a7bfc7f4db1c684" "2026-09-21T09:08:21"
```
