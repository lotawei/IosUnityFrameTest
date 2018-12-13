//
//  UnityRadiumTool.m
//  RadiumChannelSDK
//
//  Created by lotawei on 2018/12/13.
//  Copyright © 2018 lotawei. All rights reserved.
//

#import <Foundation/Foundation.h>
//#import <RadiumChannelSDK/RadiumChannelSDK-Swift.h>

typedef void (*MsgCall)(char *data,int msg);


typedef void (*nomsgCallback)();
extern "C"
{
    
    void   start(){
        NSLog(@"唤起调用");
        
        //        [[RadiumChannelSDK sharedInstance] start];
    }
    void  setcallback(char *data){
        
        NSLog(@"hello %s",data);
        //        [[RadiumChannelSDK sharedInstance] setcallback:data];
        
        
        
    }
    void  enabledebug(bool open){
        NSString *res = [NSString  stringWithFormat: open==true?@"开启打印":@"关闭打印"];
        NSLog(@"%@",res);
    }
    void  setcallmsgStr(MsgCall back){
        
        back("啥哈待会",9);
        //        [[RadiumChannelSDK sharedInstance] setcallbackmsg:back];
        
        
        
    }
    void  logout(nomsgCallback  callback){
        callback();
    }
}
