pipeline {
    agent any

    stages {
        stage('Hello') {
            steps {
                git branch: 'main', url: 'https://github.com/BossBunch/UI.MvcApplication.git'
            }
        }
        stage('Build') {
    					steps {
    					    bat "dotnet restore MVC/MVC.csproj"
    				  		bat "dotnet build MVC/MVC.csproj -c Release -o /app/build"
	    			   	    bat "dotnet publish MVC/MVC.csproj -c Release -o /app/publish"
    					    
    					}
				}

        stage('Test') {
                    steps {
                        sh(script: 'dotnet test -l:trx || true')        
                            }
                    }
    }
    post {
    always {
      mstest(testResultsFile: '**/*.trx', failOnError: false, keepLongStdio: true)
    }
  }
}