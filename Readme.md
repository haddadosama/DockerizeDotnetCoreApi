# DockerizeYourNetCoreApp

## Description
This repo will take you step by step on how to dockerize your .net application into AWS using AWS CLI and docker. This will help to script your deployment and give you more control over your requirements

### Clone the repository on your local machine:
```console
git clone https://github.com/haddadosama/DockerizeYouNetCoreApp.git
```

## Step 1: Build your Docker image and push it to ECR (Elastic Container Registry)

1. First you have to authenticate Docker to an Amazon ECR (please don't forget to select your region):

```console
Invoke-Expression -Command (Get-ECRLoginCommand -Region {{region}}).Command
```

Output:
``` 
Login Succeeded
```

2. You need to create a repository in ECR in your AWS account to be able to push the image:

```console
aws ecr create-repository --repository-name dummynetcoreapi/dev
```

Output:
``` 
{
    "repository": {
        "repositoryArn": "arn:aws:ecr:us-east-1:803942325742:repository/dummynetcoreapi/dev",
        "registryId": "803942325742",
        "repositoryName": "dummynetcoreapi/dev",
        "repositoryUri": "803942325742.dkr.ecr.us-east-1.amazonaws.com/dummynetcoreapi/dev",
        "createdAt": "2021-06-16T06:52:17-04:00",
        "imageTagMutability": "MUTABLE",
        "imageScanningConfiguration": {
            "scanOnPush": false
        },
        "encryptionConfiguration": {
            "encryptionType": "AES256"
        }
    }
}
```

3. Build your image and tag it locally on docker using the docker file available in the project:

```console
cd {{git repository location}}
docker build -t dummynetcoreapi/dev .\DummyNetCoreAPI
```

4. Now you should tag your image in the following format
```
docker tag {{Image ID}} {{AWS account ID}}.dkr.ecr.{{region}}.amazonaws.com/{{Repository Name in ECR}}
```

### Note:
you can get Image ID by running the following command

*Docker Images*

```console
docker tag 421ef83c2491 803942325742.dkr.ecr.us-east-1.amazonaws.com/dummynetcoreapi/dev
```

5. Push the image to ECR by running the push command

```console
docker push 803942325742.dkr.ecr.us-east-1.amazonaws.com/dummynetcoreapi/dev
```

Now your image should be available in your AWS account in ECR... Congratulations !! :)

## Step 2: Build VPC using the template from the repository on the following path:
{{git repository location}}\CloudFormationTemplates\01-CreateVPC.yml

1. Go to cloud formation in AWS console
2. Select Create stack
3. Select Upload a template file
4. Choose the file from your drive "01-CreateVPC.yml"
5. Fill the stack name, EnvironmentName, and projectName(to add a tag project to all recourses for easier control)
6. Add project tag with the same value you used in the previews step
7. Create the stack

## Step 3: Create ECS within the created VPC
