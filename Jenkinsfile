pipeline {
    agent any

    stages {
	    stage('Checkout')
	    {
        	steps
	    	{
				cleanWs()
				
				checkout scmGit(branches: 
                    [[name: 'stable-2.289']],
                        userRemoteConfigs: [
                            [ url: 'https://github.com/BossBunch/UI.MvcApplication.git' ]
                ]))
  		    }
	    }
    }
}
