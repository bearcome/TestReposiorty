/*
Navicat MySQL Data Transfer

Source Server         : local
Source Server Version : 50724
Source Host           : localhost:3306
Source Database       : cvcxcapital_sysdata

Target Server Type    : MYSQL
Target Server Version : 50724
File Encoding         : 65001

Date: 2018-11-03 17:35:55
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for t_userinfo_base
-- ----------------------------
DROP TABLE IF EXISTS `t_userinfo_base`;
CREATE TABLE `t_userinfo_base` (
  `pkid` int(255) NOT NULL AUTO_INCREMENT,
  `usercode` varchar(20) CHARACTER SET utf8 NOT NULL COMMENT '员工编号',
  `pycodefull` varchar(255) CHARACTER SET utf8 DEFAULT NULL COMMENT '全拼',
  `pycodeshort` varchar(255) CHARACTER SET utf8 DEFAULT NULL COMMENT '简拼',
  `usernameen` varchar(255) CHARACTER SET utf8 DEFAULT NULL COMMENT '英文名',
  `nickname` varchar(255) CHARACTER SET utf8 DEFAULT NULL COMMENT '昵称',
  `gender` varchar(255) CHARACTER SET utf8 DEFAULT NULL COMMENT '性别',
  `birthday` date DEFAULT NULL COMMENT '出生日期',
  `birthcountry` int(11) DEFAULT NULL COMMENT '出生地国家-字典',
  `birthcity` int(11) DEFAULT NULL COMMENT '出生地城市-字典',
  `nationalityid` int(11) DEFAULT NULL COMMENT '国际-字典',
  `lastrecord` int(11) DEFAULT NULL COMMENT '最高学历-字典',
  `lastschool` varchar(255) CHARACTER SET utf8 DEFAULT NULL COMMENT '学校',
  `lastspeciality` varchar(255) CHARACTER SET utf8 DEFAULT NULL COMMENT '专业',
  `lastschooldate` date DEFAULT NULL COMMENT '毕业时间',
  `checkindate` date DEFAULT NULL COMMENT '日志日期',
  `checkoutdate` date DEFAULT NULL COMMENT '离职日期',
  `userhrpic` binary(255) DEFAULT NULL COMMENT '入职照片数据',
  `userhrpictype` varchar(255) CHARACTER SET utf8 DEFAULT NULL COMMENT '入职照片类型',
  `userselfpic` binary(255) DEFAULT NULL COMMENT '当前照片',
  `userselfpictype` varchar(255) CHARACTER SET utf8 DEFAULT NULL COMMENT '当前照片类型',
  `lasttitle` int(255) DEFAULT NULL COMMENT '当前职位-字典',
  `lastjobpost` int(255) DEFAULT NULL COMMENT '当前岗位',
  `lastlevel` int(255) DEFAULT NULL COMMENT '当前级别',
  `costcenterid` int(11) DEFAULT NULL COMMENT '成本中心编码',
  `basecityid` int(11) DEFAULT NULL COMMENT '薪酬所在地-字典',
  `workcityid` int(11) DEFAULT NULL COMMENT '当前工作地',
  `towerid` int(11) DEFAULT NULL COMMENT '所在楼宇',
  `officenum` varchar(255) CHARACTER SET utf8 DEFAULT NULL COMMENT '工位编号',
  `groupid` int(11) DEFAULT NULL COMMENT '当前群组',
  `subcomid` int(11) DEFAULT NULL COMMENT '当前所属分公司id',
  `departid` int(11) DEFAULT NULL COMMENT '当前部门',
  `areaid` int(11) DEFAULT NULL COMMENT '当前区域',
  `secuserid1` int(255) DEFAULT NULL COMMENT '秘书助理主',
  `secuserid2` int(255) DEFAULT NULL COMMENT '秘书助理副',
  `phonenums` varchar(255) CHARACTER SET utf8 DEFAULT NULL COMMENT '手机',
  `callnums` varchar(255) CHARACTER SET utf8 DEFAULT NULL COMMENT '电话',
  `faxnums` varchar(255) CHARACTER SET utf8 DEFAULT NULL COMMENT '传真',
  `emailcom` varchar(255) CHARACTER SET utf8 DEFAULT NULL COMMENT '公司邮箱',
  `emailself` varchar(255) CHARACTER SET utf8 DEFAULT NULL COMMENT '个人邮箱',
  `politicalid` int(11) DEFAULT NULL COMMENT '政治面貌-字典',
  `inpartydate` date DEFAULT NULL COMMENT '入党日期',
  `lastlogdate` datetime DEFAULT NULL COMMENT '最后登录日期',
  `statusid` int(11) NOT NULL COMMENT '账号状态 0正常，1禁用',
  `isdeleted` int(255) NOT NULL COMMENT '是否逻辑删除  0-可用，1-已删除',
  `updatetime` datetime DEFAULT NULL COMMENT '信息更新时间',
  `updateuserid` int(11) NOT NULL COMMENT '信息更新人',
  PRIMARY KEY (`pkid`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of t_userinfo_base
-- ----------------------------
INSERT INTO `t_userinfo_base` VALUES ('1', 'asd', 'zhangsan', 'zs', '??', 'niickname', '?', '2038-11-01', '1', '1', '1', null, 'beida', 'computer', '2013-11-01', '2018-10-10', null, null, null, null, null, '1', '1', '1', '1', '1', '10', '12', '12345', '1', '10', '1', null, '4', '5', '1233457', '13305331614', '123245', '123@qq.com', '234@qq.com', '2', '2015-11-01', '2018-11-01 11:59:05', '0', '0', '2018-11-01 11:59:05', '1');

-- ----------------------------
-- Table structure for t_user_edu
-- ----------------------------
DROP TABLE IF EXISTS `t_user_edu`;
CREATE TABLE `t_user_edu` (
  `pkid` int(11) NOT NULL AUTO_INCREMENT,
  `userid` int(11) NOT NULL COMMENT '员工id',
  `university` varchar(255) DEFAULT NULL COMMENT '学校',
  `city` int(255) DEFAULT NULL COMMENT '所在城市',
  `startdate` date DEFAULT NULL COMMENT '开始日期',
  `enddate` date DEFAULT NULL COMMENT '截止日期',
  `education` int(255) DEFAULT NULL,
  `major` varchar(255) DEFAULT NULL COMMENT '专业',
  `desc` text,
  `updatetime` datetime NOT NULL COMMENT '信息更新时间',
  `updateuserid` int(11) NOT NULL COMMENT '信息更新人',
  PRIMARY KEY (`pkid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_user_edu
-- ----------------------------

-- ----------------------------
-- Table structure for t_user_relation
-- ----------------------------
DROP TABLE IF EXISTS `t_user_relation`;
CREATE TABLE `t_user_relation` (
  `pkid` int(11) NOT NULL AUTO_INCREMENT,
  `userid` int(11) NOT NULL COMMENT '员工id',
  `name` varchar(255) DEFAULT NULL COMMENT '姓名',
  `gender` varchar(255) DEFAULT NULL COMMENT '性别',
  `nationalityid` int(255) DEFAULT NULL COMMENT '国籍',
  `nation` varchar(255) DEFAULT NULL COMMENT '民族',
  `relationship` int(255) NOT NULL COMMENT '关系 字典',
  `location` int(255) DEFAULT NULL COMMENT '所在地  ',
  `company` varchar(255) DEFAULT NULL COMMENT '工作单位',
  `occupation` varchar(255) DEFAULT NULL COMMENT '职业',
  `post` varchar(255) DEFAULT NULL COMMENT '岗位',
  `isparty` varchar(255) DEFAULT NULL,
  `desc` text,
  PRIMARY KEY (`pkid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_user_relation
-- ----------------------------

-- ----------------------------
-- Table structure for t_user_resume
-- ----------------------------
DROP TABLE IF EXISTS `t_user_resume`;
CREATE TABLE `t_user_resume` (
  `okid` int(11) NOT NULL AUTO_INCREMENT,
  `userid` int(11) NOT NULL COMMENT '员工id',
  `belcompany` varchar(255) DEFAULT NULL COMMENT '所在单位',
  `startdate` date NOT NULL COMMENT '工作开始日期',
  `enddate` date DEFAULT NULL COMMENT '工作时间截止',
  `lasttitle` varchar(255) DEFAULT NULL COMMENT '最终职位',
  `lastjobpost` varchar(255) DEFAULT NULL COMMENT '最终级别',
  `lastlevel` varchar(255) DEFAULT NULL COMMENT '最终级别',
  `salary` int(10) DEFAULT NULL COMMENT '薪资',
  `reporttoleader` varchar(255) DEFAULT NULL COMMENT '汇报对象',
  `leadertitle` varchar(255) DEFAULT NULL COMMENT '汇报人职位',
  `leaderlevel` varchar(255) DEFAULT NULL COMMENT '汇报人级别',
  `dutydesc` text COMMENT '职责说明',
  `updatetime` datetime NOT NULL,
  `updateuserid` int(11) NOT NULL,
  PRIMARY KEY (`okid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_user_resume
-- ----------------------------
