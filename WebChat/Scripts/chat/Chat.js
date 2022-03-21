// 引用自动生成的集线器代理
var chat = $.connection.chatHub;
$(function () {
    /*
    $('#hid_touserid').val('');
    $('#textMessage').focus();
    $('.js-tab-item').eq(0).siblings('.js-tab-item').hide();//先隐藏除第一个以外的tab
    //tab切换
    $('.js-tab').on('click', function (e) {
        $(this).siblings('.js-tab').toggleClass('js-li-active');
        $(this).toggleClass('js-li-active');

        var id = $('.js-tab').filter('.js-li-active').attr('href').substr(1);
        $('#' + id).toggle();
        $('#' + id).siblings('.js-tab-item').toggle();
    });
    */
    // 开始连接服务器
    //document.getElementById("friends").setAttribute("friends","")
    $.connection.hub.start().done(function () {
        $('#btnSend').click(function () {
            var msg = $('#textMessage').val().trim();
            if (msg == "" || msg == undefined || msg == null) {
                alert("请输入聊天信息");
                $('#textMessage').focus();
            } else {
                // 调用服务器端集线器的Send方法
                chat.server.publicSendMsg(msg, current_userid);
                // 清空输入框信息并获取焦点
                $('#textMessage').val('').focus();
            }
        }) 
        //添加在线用户
        chat.server.addOnlineUser(current_uname, current_pwd, current_userid);
        
        //获取在线用户集合
        //chat.server.getAllOnlineUser();
        //获取好友集合
        chat.server.getFriends();
    }) .fail(function (error) {
        alert('Invocation of start failed. Error:' + error)
    });

    //显示新用户加入消息
    chat.client.showJoinMessage = function (nickName, connectionid) {
        $("#js-panel-content").append('<div class="js-time text-white text-center"><span>' + nickName + ':' + connectionid + '加入了聊天</span></div>');
    }
    ///显示大厅消息
    chat.client.sendPublicMessage = function (userid, username, message) {
        var direction = userid === current_userid ? 'right' : 'left';
        var str = '<div class="col-sm-12"><div class="js-msg-' + direction + ' clearfix text-black"><div class="js-msg-img pull-' + direction + '">'
            + '<img src="/Images/avatar.jpg" width="50" height="50" /></div><div class="js-msg-text pull-' + direction + '"><div class="js-msg-nick text-' + direction + '">' + username + '</div>'
            + '<div class="js-msg-info bg-white">' + message + '</div></div></div></div>';
        $("#js-panel-content").append(str);
    };

    //显示好友列表
    chat.client.showFriendList = function (id, data) {
        if (id == current_userid) {
            $("#friends").html('');
            var html = '<div class="js-users">';
            var allUsers = $.parseJSON(data);
            if (allUsers != null) {
                for (var i = 0; i < allUsers.length; i++) {
                    if (allUsers[i].IsOnline == 1)
                        var status = '在线';
                    else
                        var status = '离线';
                    html += '<div class="js-user clearfix" userid =' + allUsers[i].Id + ' username = ' + allUsers[i].UserName + '>' +
                        '<div class="pull-left" style = "margin-left: 50px" >' +
                        '<img src=' + allUsers[i].ImgUrl + ' style="width:40px;height:40px;border-radius: 50%;">' +
                        '<span style="margin-left:10px;display: block;width: 50px;float: left;">' + allUsers[i].UserName + '</span >' +
                        '<span style="color: coral;font - size: x - small;"> ' + status + '</span>' +
                        '</div ></div>';
                }
            }
            html += '</div>';
            $("#friends").html(html);
        }

        //点击选择好友聊天事件
        $(".js-user").each(function () {
            $(this).click(function () {
                var userid = $(this).attr('userid');
                var username = $(this).attr('username');
                var str = '<a href="javascript:;" type="'+userid+'" id="friend-center" onclick="friend_center(this.type)" style="font-weight:bold" >  ' + username + '   </a>';
                $("#hid_touserid").val(userid + '');
                $(".js-friend-title").html(str);
                //获取好友聊天记录
                chat.server.getMsgHistory(current_userid, userid);
                $("#js-chat-friends").show();//好友窗口
                $("#js-chat-panel").hide();//大厅窗口
                $("#js-apply-panel").hide();
                $("#js-friends-center").hide();
            })

        });

        ////好友信息中心
    };
    //显示私聊消息
    chat.client.showMsgToPages = function (userId, imgurl, message) {
        getPriMsgHtml(userId, imgurl, message);
    }
    //接收私聊消息提醒
    chat.client.remindMsg = function (fromuserid, fromImgurl, message) {
        var touserid = $("#hid_touserid").val();
        if (touserid != fromuserid)//如果当前聊天的id不相同
        {
            if (confirm("您收到一条消息")) {
                chat.server.getMsgHistory(1, fromuserid, current_userid, "");
                $("#hid_touserid").val(fromuserid + '');
                $(".js-friend-title").html(fromusername);
                $("#js-chat-friends").show();//好友窗口
                $("#js-chat-panel").hide();//大厅窗口
                $("#js-apply-panel").hide();
                $("#js-friends-center").hide();
            }
        } else {
            getPriMsgHtml(fromuserid, fromImgurl, message);
        }
    }
    //拼接聊天记录
    //<div class="js-msg-nick text-' + direction + '">' + sendname + '</div>'
    function getPriMsgHtml(userId, imgurl, message) {
        var direction = userId === current_userid ? 'right' : 'left';
        var str1 = '<div class="js-msg-right clearfix text-black"><div class="js-msg-img-' + direction + ' pull-' + direction + '" ><img src=' + imgurl + ' style="width: 50px; height: 50px; border-radius: 50% "></div><div class="js-msg-text-' + direction + ' pull-' + direction + 'right">'
            + '<div class="js-msg-info-' + direction + '">' + message + '</div></div></div > ';
        $("#js-friend-content").append(str1);
        var showContent = $("#js-friend-content");
        showContent[0].scrollTop = showContent[0].scrollHeight;
    }

    ///显示聊天记录
    chat.client.initChatHistoryData = function (data,fromimg,toimg) {
        if (data != null) {
            var list = $.parseJSON(data);
            $("#js-friend-content").html(getStrHtml(list, fromimg, toimg));
        }
    }

    //拼接字符串
    function getStrHtml(list,fromimg,toimg) {
        var str = '';
        var len = list.length;
        for (var i = 0; i < len; i++) {
            var direction = list[i].FromId === current_userid ? 'right' : 'left';
            var imgurl = list[i].FromId === current_userid ? fromimg : toimg;
            str += '<div class="js-msg-right clearfix text-black"><div class="js-msg-img-' + direction + ' pull-' + direction + '" ><img src=' + imgurl + ' style="width: 50px; height: 50px; border-radius: 50% "></div><div class="js-msg-text-' + direction + ' pull-' + direction + 'right">'
                + '<div class="js-msg-info-' + direction + '">' + list[i].Content + '</div></div></div > ';
        }
        return str;
    }
})

//跳转到好友申请页面
$("#friends-apply").click(function () {
    $("#js-chat-panel").hide();
    $("#js-chat-friends").hide();
    $("#js-apply-panel").show();
    $("#js-friends-center").hide();
    chat.server.getApply(current_userid);

});

//好友中心
function friend_center(id) {

    $("#js-chat-friends").hide();
    $("#js-friends-center").show();
    var userid = id;
    document.getElementById('js-friend-id').innerHTML = id;
    chat.server.setFriendCenter(current_userid,id);
    
};

//显示结果
chat.client.showFriendCenter = function (data) {
    var Friend = $.parseJSON(data);
    document.getElementById('js-friend-username').innerHTML = Friend.UserName;
    document.getElementById('js-friend-nickname').innerHTML = Friend.NickName;
    var obj = document.getElementById("friend-center-img");
    obj.src = Friend.ImgUrl;//能设置
};
//发送消息给指定好友;;
$("#btnFriendSend").click(function () {
    var hid_userid = $("#hid_touserid").val();
    var txtmsg = $("#txtfriendMsg").val();
    if (hid_userid == null || hid_userid == "" || hid_userid == "undefined") {
        alert("请选择一个好友进行聊天");
    } else if (txtmsg == null || txtmsg == "" || txtmsg == "undefined") {
        alert("请输入聊天内容");
        $("#txtfriendMsg").focus();
    }
    else {
        $("#txtfriendMsg").val('');
        $("#txtfriendMsg").focus();
        chat.server.sendMsg(current_userid, hid_userid, txtmsg);
    }
})
///关闭好友聊天窗口
$("#js-user-close").click(function () {
    showHome();
});
//从好友中心返回
$("#js-user-back").click(function () {
    $("#js-chat-friends").show();
    $("#js-friends-center").hide();
});

//删除好友
$("#js-friend-delete").click(function () {
    var id = document.getElementById('js-friend-id').innerHTML;
    chat.server.deleteFriend(current_userid, id);
    alert("删除成功");
    window.location.reload();
});


$("body").keydown(function () {
    if (event.keyCode == "13") {//keyCode=13是回车键
        $("#btnFriendSend").click();
    }
});

//搜索
$("#js-user-search").click(function () {
    var content = $("#search-content").val();
    if (content == null || content == "" || content == "undefined") {
        alert("请输入搜索内容");
        $("#search-content").focus();
    }
    else {
        chat.server.searchUser(current_userid, content);
    }
    
});
//显示搜索结果
chat.client.showSearch = function (id, data) {
    if(id == current_userid)
    {
        $('#js-searched-user').html('');
        var html = '<div class="js-users">';
        var allUsers = $.parseJSON(data);
        if (allUsers != null) {
            for (var i = 0; i < allUsers.length; i++) {
                if (allUsers[i].IsOnline == 1)
                    var status = '在线';
                else
                    var status = '离线';
                html += '<div class="js-user clearfix" userid =' + allUsers[i].Id + ' username = ' + allUsers[i].UserName + '>' +
                    '<div class="pull-left" style = "margin-left: 5%" >' +
                    '<img src=' + allUsers[i].ImgUrl + ' style="width:40px;height:40px;border-radius: 50%;">' +
                    '<span style="margin-left:10px;display: block;width: 50px;float: left;color:black">' + allUsers[i].UserName + '</span >' +
                    '<span style="color: coral;font - size: x - small;"> ' + status + '</span>' +
                    '<a  href="javascript:;" class="js-user-add" userid =' + allUsers[i].Id + ' style="background-color: #5BD8D2;float: right;width: 50px;height: 30px;text-align: center;margin-right: 5%;line-height: initial;margin-top: 10px;border-radius: 5px;color: white; border: solid 1px #2c2727;">添加</a>'+
                    '</div ></div>';
            }
        }
        html += '</div>';
        $('#js-searched-user').html(html);
    }
    

    //添加好友
    $(".js-user-add").each(function () {
        $(this).click(function () {
            var userid = $(this).attr('userid');

            var name = prompt("请输入他的昵称:", "");
            console.log(name);
            console.log(typeof (name));
            if (name == "") {

                alert("输入不能为空!");

            }

            chat.server.addUser(current_userid, userid,name);

            alert("申请成功");
            $("#js-user-search").click();
            
        })
    });

}

//显示申请结果
chat.client.showApply = function (id, data) {
    if (id == current_userid) {
        $('#js-apply-user').html('');
        var html = '<div class="js-users">';
        var allUsers = $.parseJSON(data);
        if (allUsers != null) {
            for (var i = 0; i < allUsers.length; i++) {
                html += '<div class="js-user clearfix" userid =' + allUsers[i].Id + ' username = ' + allUsers[i].UserName + '>' +
                    '<div class="pull-left" style = "margin-left: 5%" >' +
                    '<img src=' + allUsers[i].ImgUrl + ' style="width:40px;height:40px;border-radius: 50%;">' +
                    '<span style="margin-left:10px;display: block;width: 50px;float: left;color:black">' + allUsers[i].UserName + '</span >' +
                    '<a  href="javascript:;" class="js-apply-accept" userid =' + allUsers[i].Id + ' style="background-color: #5BD8D2;float: right;width: 50px;height: 30px;text-align: center;margin-right: 5%;line-height: initial;margin-top: 10px;border-radius: 5px;color: white; border: solid 1px #2c2727;">同意</a>' +
                    '<a  href="javascript:;" class="js-apply-refuse" userid =' + allUsers[i].Id + ' style="background-color: #5BD8D2;float: right;width: 50px;height: 30px;text-align: center;margin-right: 5%;line-height: initial;margin-top: 10px;border-radius: 5px;color: white; border: solid 1px #2c2727;">拒绝</a>' +
                    '</div ></div>';
            }
        }
        html += '</div>';
        $('#js-apply-user').html(html);
    }

    //同意好友申请
    $(".js-apply-accept").each(function () {
        $(this).click(function () {
            var userid = $(this).attr('userid');
            var name = prompt("请输入他的昵称:", "");
            console.log(name);
            console.log(typeof (name));
            if (name == "")
             {

                alert("输入不能为空!");

            }
            chat.server.acceptApply(current_userid,userid,name);
            alert("同意成功");
            chat.server.getApply(current_userid);
        })
    });
    //拒绝好友申请
    $(".js-apply-refuse").each(function () {
        $(this).click(function () {
            var userid = $(this).attr('userid');
            chat.server.refuseApply(current_userid, userid);
            alert("拒绝成功");
            chat.server.getApply(current_userid);
        })
    });
};


///显示主页面板
function showHome() {
    $("#js-chat-panel").show();
    $("#js-chat-friends").hide();
    $("#js-apply-panel").hide();
    $("#js-friends-center").hide();
    $("#js-friend-content").html('');//清空好友聊天内容
    $("#hid_roomid").val('');
    $("#hid_touserid").val('');
    chat.server.getMsgHistory(0);//获取大厅历史记录
}